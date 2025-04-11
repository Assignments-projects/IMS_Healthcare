using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces.Patient;
using ServiceLayer.Interfaces.Settings;
using ServiceLayer.Interfaces;
using DbLayer.Helpers;
using DbLayer.Models.Patient;
using Web.Helper;
using Web.Models.Image;
using DbLayer.Models.Settings;
using ServiceLayer.Services.Patient;
using Web.Models.Settings;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Web.Controllers
{
	public class ImageController : BaseController
	{
		private readonly IImageService _image;
		private readonly IDiseaseService _disease;
		private readonly IPatientsService _patient;
		private readonly IStaffService _staff;
		private readonly IImageTypeService _imageType;
		private readonly IDiseaseTypeService _diseaseType;
		private readonly IMapper _mapper;
		private readonly IConfiguration _config;

		public ImageController(
			IImageService image,
			IDiseaseService disease,
			IPatientsService patient,
			IStaffService staff,
			IImageTypeService imageType,
			IDiseaseTypeService diseaseType,
			IMapper mapper,
			IConfiguration config)
		{
			_image = image;
			_disease = disease;
			_patient = patient;
			_staff = staff;
			_imageType = imageType;
			_diseaseType = diseaseType;
			_mapper = mapper;
			_config = config;
		}

		/// <summary>
		/// Image index page
		/// </summary>
		/// <returns></returns>
		public IActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Image classified page
		/// </summary>
		/// <returns></returns>
		public IActionResult Classified()
		{
			return View();
		}

		/// <summary>
		/// Load list of images
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> ImageList()
		{
			var images = await _image.ListAsync();
			var model = _mapper.Map<List<ImageVM>>(images);

			return PartialView("Containers/_ImageList", MakeImage(model));
		}

		/// <summary>
		/// Load list of images belongs to disease id
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> DiseaseImageList(int id)
		{
			var images = await _image.ListAsync(id);
			var model  = _mapper.Map<List<ImageVM>>(images);

			return PartialView("Containers/_ImageList", MakeImage(model));
		}

		/// <summary>
		/// Load list of images classified belong tot he type passed
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public async Task<PartialViewResult> ImageVsList(string type)
		{
			if(type == nameof(ImageWith.DiseaseType))
			{
				// Get disease types available
				var model = _mapper.Map<List<DiseaseTypeVM>>(await _diseaseType.ListAsync());

				if (!model.Any())
					return await EmptyDiseaseType();

				foreach (var t in model)
				{
					if (t.Diseases == null && !t.Diseases.Any())
						return await EmptyDiseaseType();

					foreach (var d in t.Diseases)
					{
						if (d.Images == null && !d.Images.Any())
							return await EmptyDiseaseType();

						d.Images = MakeImage(d.Images);
					}
				}

				return PartialView("Containers/_ImageVsDiseaseType", model);

			}

			// Get image types available
			var imgModel = _mapper.Map<List<ImageTypeVM>>(await _imageType.ListAsync());

			if (!imgModel.Any())
				return await EmptyImageType();

			foreach (var t in imgModel)
			{
				if(t.Images == null && !t.Images.Any())
					return await EmptyImageType();

				t.Images = MakeImage(t.Images);
			}

			return PartialView("Containers/_ImageVsType", imgModel);


			// Empty return for image type
			async Task<PartialViewResult> EmptyImageType()
			{
				return PartialView("Containers/_ImageVsType", new List<ImageTypeVM>());
			}

			// Empty return for disease type
			async Task<PartialViewResult> EmptyDiseaseType()
			{
				return PartialView("Containers/_ImageVsDiseaseType", new List<DiseaseTypeVM>());
			}
		}

		/// <summary>
		/// Load details of image by id
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> ImageDetails(int id)
		{
			var image = await _image.DetailsAsync(id);
			var model = _mapper.Map<ImageVM>(image);

			return PartialView("Popups/_ImageDetails", MakeImage(model));
		}

		/// <summary>
		/// Load Add modal for image
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new ImageDetailsVM()
			{
				ImageTypeList   = await _imageType.ImageTypeSelectList(),
				DiseaseList     = await _disease.DiseaseSelectList(),
			};

			return PartialView("Popups/_AddEditImage", model);
		}

		/// <summary>
		/// Add image to the database
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Add(ImageDetailsVM model)
		{
			if (!TryValidateModel(model.Details, nameof(model.Details)))
				return JsonError("Fields are not valid");

			if (model.File == null || model.File.Length <= 0)
				return JsonError("Image file not found");

			var modelWithFile = await MakeFile(model.File, model.Details);

			var image  = _mapper.Map<Image>(modelWithFile);
			var result = await _image.AddAsync(image, UserHelper.GetCurrentUser());

			if (!string.IsNullOrEmpty(result))
				return JsonError(result);

			return JsonSuccess("Image added successfully.");
		}

		/// <summary>
		/// Load delete modal belongs to given image id
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<PartialViewResult> Delete(int id)
		{
			var image = await _image.DetailsAsync(id);
			var model = _mapper.Map<ImageVM>(image);

			return PartialView("Popups/_DeleteImage", model);
		}

		/// <summary>
		/// Delete image for the details given and return json
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<JsonResult> Delete(ImageVM model)
		{
			var result = await _image.DeleteAsync((int)model.ImageId);

			if (!string.IsNullOrEmpty(result))
				return JsonError(result);

			return JsonSuccess("Image deleted successfully.");
		}

		/// <summary>
		/// Get Image from model file ocntents
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Download(ImageVM model)
		{
			var result = new
			{
				success = true,
				message = "File downloaded successfully.",
				url     = Url.Action("Download", new { id = model.ImageId })
			};

			return Json(result);
		}

		/// <summary>
		/// Get Image from model file ocntents
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> Download(int id)
		{
			var result = await _image.DetailsAsync(id);

			if (result == null)
				return await NotFound();

			var decryptedBytes = DecryptFile(result.FileContent);

			return File(decryptedBytes, result.MimeType, result.FileName);
		}

		/// <summary>
		/// Get Image from model file content
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<IActionResult> GetImage(int id)
		{
			var result = await _image.DetailsAsync(id);

			if (result == null)
				return NoContent();

			var decryptedBytes = DecryptFile(result.FileContent);

			return File(decryptedBytes, result.MimeType);
		}

		/// <summary>
		/// Make file details and attach to model
		/// </summary>
		/// <param name="image"></param>
		/// <returns></returns>
		private async Task<ImageVM> MakeFile(IFormFile file, ImageVM model)
		{
			using (var stream = new MemoryStream())
			{
				await file.CopyToAsync(stream);

				var encryptedBytes = EncryptFile(stream.ToArray());

				model.FileName    = file.FileName;
				model.MimeType    = file.ContentType;
				model.FileContent = encryptedBytes;

				return model;
			}
		}

		/// <summary>
		/// Add the image url for the object
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		private ImageVM MakeImage(ImageVM model)
		{
			if (model == null)
				return new ImageVM();

			model.ImageUrl = Url.Action("GetImage", new { id = model.ImageId });

			return model;
		}

		/// <summary>
		/// Add the image url for the list
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		private List<ImageVM> MakeImage(List<ImageVM> model)
		{
			if(!model.Any())
				return new List<ImageVM>();

			foreach(var image in model)
			{
				image.ImageUrl = Url.Action("GetImage", new { id = image.ImageId });
			}
			return model;
		}

		/// <summary>
		/// Add the image url for the list
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		private ICollection<ImageVM> MakeImage(ICollection<ImageVM> model)
		{
			if (!model.Any())
				return new List<ImageVM>();

			foreach (var image in model)
			{
				image.ImageUrl = Url.Action("GetImage", new { id = image.ImageId });
			}
			return model;
		}

		/// <summary>
		/// Encript file byte array
		/// </summary>
		/// <param name="fileBytes"></param>
		/// <returns></returns>
		private byte[] EncryptFile(byte[] fileBytes)
		{
			using var aes = Aes.Create();
			aes.Key       = Encoding.UTF8.GetBytes(_config["Crypto:Key"]);
			aes.IV        = Encoding.UTF8.GetBytes(_config["Crypto:IV"]);

			using var encryptor = aes.CreateEncryptor();
			return encryptor.TransformFinalBlock(fileBytes, 0, fileBytes.Length);
		}

		/// <summary>
		/// Decript file byte array
		/// </summary>
		/// <param name="encryptedBytes"></param>
		/// <returns></returns>
		private byte[] DecryptFile(byte[] encryptedBytes)
		{
			using var aes = Aes.Create();
			aes.Key       = Encoding.UTF8.GetBytes(_config["Crypto:Key"]);
			aes.IV        = Encoding.UTF8.GetBytes(_config["Crypto:IV"]);

			using var decryptor = aes.CreateDecryptor();
			return decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
		}
	}
}
