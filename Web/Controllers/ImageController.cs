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

		public ImageController(
			IImageService image,
			IDiseaseService disease,
			IPatientsService patient,
			IStaffService staff,
			IImageTypeService imageType,
			IDiseaseTypeService diseaseType,
			IMapper mapper)
		{
			_image       = image;
			_disease     = disease;
			_patient     = patient;
			_staff       = staff;
			_imageType   = imageType;
			_diseaseType = diseaseType;
			_mapper = mapper;
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
		/// Load list of images
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> ImageList()
		{
			var images = await _image.ListAsync();
			var model  = _mapper.Map<List<ImageVM>>(images);

			return PartialView("Containers/_ImageList", MakeImage(model));
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

			return File(result.FileContent, result.MimeType, result.FileName);
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

			return File(result.FileContent, result.MimeType);
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

				model.FileName    = file.FileName;
				model.MimeType    = file.ContentType;
				model.FileContent = stream.ToArray();

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
	}
}
