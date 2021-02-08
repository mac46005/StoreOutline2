using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataManager.Library.DataAccess;
using DataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StoreOutline2.Areas.Admin.Models;

namespace StoreOutline2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class ProductInfoManagerController : Controller
    {
        private string _tempKey = "message";
        private IConfiguration _config;
        private IBrand_Data _brand_Data;
        private IGeneralType_Data _genType_Data;
        public ProductInfoManagerController(IConfiguration config, IBrand_Data brand_Data, IGeneralType_Data genTypeData)
        {
            _config = config;
            _brand_Data = brand_Data;
            _genType_Data = genTypeData;
        }
        public IActionResult Index()
        {
            return View();
        }









        [HttpGet]
        public IActionResult AddEditBrand(int? id)
        {
            if (id != null)
            {
                ViewBag.AddEdit = "Edit";
                var brandDataModel = _brand_Data.GetById((int)id);
                ViewBag.BrandName = brandDataModel.Name;
                return View(new BrandModel { Id = brandDataModel.Id, Name = brandDataModel.Name, Description = brandDataModel.Description });
            }
            else
            {
                ViewBag.AddEdit = "Add";
                return View();
            }

        }
        [HttpPost]
        public IActionResult AddEditBrand(BrandModel brandModel)
        {
            if (ModelState.IsValid)
            {
                if (brandModel.Id != null)
                {
                    _brand_Data.EditBrand(new BrandDataModel { Id = brandModel.Id, Name = brandModel.Name, Description = brandModel.Description });
                    TempData[_tempKey] = $"Succesfully edited Brand: {brandModel.Name.ToUpper()}";
                    return RedirectToAction("Index");
                }
                else
                {
                    _brand_Data.SaveBrand(new BrandDataModel { Name = brandModel.Name, Description = (brandModel.Description ?? string.Empty) });
                    TempData[_tempKey] = $"Successfully Added new Brand: {brandModel.Name}";
                    return RedirectToAction("Index");
                }

            }
            else
            {
                return View(brandModel);
            }
        }
        public IActionResult BrandList()
        {
            List<BrandModel> brandModelList = new List<BrandModel>();
            var brandDataModelList = _brand_Data.GetAll();
            foreach (var brand in brandDataModelList)
            {
                brandModelList.Add(new BrandModel { Id = brand.Id, Name = brand.Name, Description = brand.Description });
            }
            return View(brandModelList);
        }








        [HttpGet]
        public IActionResult AddEditGeneralType(int? id)
        {
            if (id != null)
            {
                ViewBag.AddEdit = "Edit";
                var genTypeDataModel = _genType_Data.GetById((int)id);
                return View(new GeneralTypeModel { Id = genTypeDataModel.Id, TypeName = genTypeDataModel.TypeName });
            }
            else
            {
                ViewBag.AddEdit = "Add";
                return View();
            }

        }
        [HttpPost]
        public IActionResult AddEditGeneralType(GeneralTypeModel generalTypeModel)
        {
            if (ModelState.IsValid)
            {
                if (generalTypeModel.Id != null)
                {
                    _genType_Data.Edit(new GeneralTypeDataModel { Id = generalTypeModel.Id, TypeName = generalTypeModel.TypeName });
                    TempData[_tempKey] = $"Succesfully edited General Type: {generalTypeModel.TypeName.ToUpper()}.";
                    return RedirectToAction("Index");
                }
                else
                {
                    _genType_Data.Save(new GeneralTypeDataModel { TypeName = generalTypeModel.TypeName });
                    TempData[_tempKey] = $"Successfully added new General Type: {generalTypeModel.TypeName.ToUpper()}.";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(generalTypeModel);
            }
        }

        public IActionResult GeneralTypeList()
        {
            List<GeneralTypeModel> genTypeList = new List<GeneralTypeModel>();
            var genTypeDataModelList = _genType_Data.GetAll();
            genTypeDataModelList.ForEach(x =>
            {
                genTypeList.Add(new GeneralTypeModel { Id = x.Id, TypeName = x.TypeName });
            });
            return View(genTypeList);
        }








        public IActionResult AddEditSubType()
        {
            return View();
        }
































        [HttpGet]
        public IActionResult Delete(string category, int id, string name)
        {

            return View(new DeleteModel { Category = category, Id = id, Name = name });
        }
        [HttpPost]
        public IActionResult Delete(DeleteModel deleteModel)
        {
            IActionResult result = View(deleteModel);

            if (deleteModel.Category == "Brand")
            {
                _brand_Data.Delete(deleteModel.Id);
                result = RedirectToAction("BrandList");
            }
            else if (deleteModel.Category == "GeneralType")
            {
                _genType_Data.Delete(deleteModel.Id);
                result = RedirectToAction("GeneraltypeList");
            }
            else
            {
                result = View(deleteModel);
            }
            TempData["deleted"] = $"{deleteModel.Name} has been deleted";
            return result;

        }

    }
}
