using AuthLayer.Interfaces;
using AutoMapper;
using DbLayer.Helpers;
using DbLayer.Models.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces.Settings;
using Web.Helper;
using Web.Models.Role;
using Web.Models.Settings;

namespace Web.Controllers
{
	public class SettingsController : BaseController
	{

		private readonly IImageTypeService _imageType;
		private readonly IDiseaseTypeService _diseaseType;
		private readonly IMapper _mapper;

		public SettingsController(
			IImageTypeService imageType,
			IDiseaseTypeService diseaseType,
			IMapper mapper)
		{
			_imageType = imageType;
			_diseaseType = diseaseType;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Image type main page
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> ImageType()
		{
			return View();
		}

		/// <summary>
		/// Disease type main page
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> DiseaseType()
		{
			return View();
		}


		// Image type operation region
		#region Images Type

		/// <summary>
		/// Load list of image types
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> ImageTypeList()
		{
			var imageTypes = await _imageType.ListAsync();
			var model = _mapper.Map<List<ImageTypeVM>>(imageTypes);

			return PartialView("Containers/_ImageTypeList", model);
		}

		/// <summary>
		/// Load Add of edit modal for image type based on id passed
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<PartialViewResult> AddEditImageType(int id)
		{
			if (id.IsZeroOrLess())
				return PartialView("Popups/_AddEditImageType");

			var imageType = await _imageType.DetailsAsync(id);
			var model     = _mapper.Map<ImageTypeVM>(imageType);

			return PartialView("Popups/_AddEditImageType", model);
		}

		/// <summary>
		/// Add or edit image type
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> AddEditImageType(ImageTypeVM model)
		{
			if (!ModelState.IsValid)
				return JsonError("Fields are not valid");

			var imageType = _mapper.Map<ImageType>(model);
			var result = string.Empty;
			var isAdd = model.ImageTypeId.IsNullOrZero();

			if (isAdd)
				result = await _imageType.AddAsync(imageType, UserHelper.GetCurrentUser());
			else
				result = await _imageType.UpdateAsync(imageType, UserHelper.GetCurrentUser());

			if (!string.IsNullOrEmpty(result))
				return JsonError("Submit image type unsuccessful.");

			return JsonSuccess($"Image type {(isAdd ? "added" : "updated")} successfully.");
		}

		/// <summary>
		/// Load delete modal belongs to given image type id
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<PartialViewResult> DeleteImageType(int id)
		{
			var imageType = await _imageType.DetailsAsync(id);
			var model = _mapper.Map<ImageTypeVM>(imageType);

			return PartialView("Popups/_DeleteImageType", model);
		}

		/// <summary>
		/// Delete image type for the details given and return json
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<JsonResult> DeleteImageType(ImageTypeVM model)
		{
			var result = await _imageType.DeleteAsync((int)model.ImageTypeId);

			if (!string.IsNullOrEmpty(result))
				return JsonError("Delete unsuccessful.");

			return JsonSuccess("Image type deleted successfully.");
		}

		#endregion

		// Disease type operation region
		#region Disease Type

		/// <summary>
		/// Load list of disease types
		/// </summary>
		/// <returns></returns>
		public async Task<PartialViewResult> DiseaseTypeList()
		{
			var diseaseTypes = await _diseaseType.ListAsync();
			var model = _mapper.Map<List<DiseaseTypeVM>>(diseaseTypes);

			return PartialView("Containers/_DiseaseTypeList", model);
		}

		/// <summary>
		/// Load Add of edit modal for disease type based on id passed
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<PartialViewResult> AddEditDiseaseType(int id)
		{
			if (id.IsZeroOrLess())
				return PartialView("Popups/_AddEditDiseaseType");

			var diseaseType = await _diseaseType.DetailsAsync(id);
			var model = _mapper.Map<DiseaseTypeVM>(diseaseType);

			return PartialView("Popups/_AddEditDiseaseType", model);
		}

		/// <summary>
		/// Add or edit disease type
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> AddEditDiseaseType(DiseaseTypeVM model)
		{
			if (!ModelState.IsValid)
				return JsonError("Fields are not valid");

			var diseaseType = _mapper.Map<DiseaseType>(model);
			var result = string.Empty;
			var isAdd = model.DiseaseTypeId.IsNullOrZero();

			if (isAdd)
				result = await _diseaseType.AddAsync(diseaseType, UserHelper.GetCurrentUser());
			else
				result = await _diseaseType.UpdateAsync(diseaseType, UserHelper.GetCurrentUser());

			if (!string.IsNullOrEmpty(result))
				return JsonError("Submit disease type unsuccessful.");

			return JsonSuccess($"Disease type {(isAdd ? "added" : "updated")} successfully.");
		}

		/// <summary>
		/// Load delete modal belongs to given disease type id
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<PartialViewResult> DeleteDiseaseType(int id)
		{
			var diseaseType = await _diseaseType.DetailsAsync(id);
			var model = _mapper.Map<DiseaseTypeVM>(diseaseType);

			return PartialView("Popups/_DeleteDiseaseType", model);
		}

		/// <summary>
		/// Delete disease type for the details given and return json
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<JsonResult> DeleteDiseaseType(DiseaseTypeVM model)
		{
			var result = await _diseaseType.DeleteAsync((int)model.DiseaseTypeId);

			if (!string.IsNullOrEmpty(result))
				return JsonError("Delete unsuccessful.");

			return JsonSuccess("Disease type deleted successfully.");
		}

		#endregion
	}
}
