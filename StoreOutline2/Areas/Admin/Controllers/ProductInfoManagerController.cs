using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataManager.Library.DataAccess;
using DataManager.Library.Helper;
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
        private IProductClass_Data _genType_Data;
        private IProductType_Data _subType_Data;
        private IPIM_Helper _pim_Helper;
        public ProductInfoManagerController(IConfiguration config,
            IBrand_Data brand_Data, IProductClass_Data genTypeData, IProductType_Data subType_Data,
            IPIM_Helper pim_Helper)
        {
            _config = config;
            _brand_Data = brand_Data;
            _genType_Data = genTypeData;
            _subType_Data = subType_Data;
            _pim_Helper = pim_Helper;
        }
        public IActionResult Index()
        {
            return View();
        }






        string duplicateErrorMessage = "This value already exists in the database: ";

        /// Brand
        /// 
        /// 
        /// 
        [HttpGet]
        public IActionResult AddEditBrand(int? id)
        {
            if (id != null)
            {
                ViewBag.AddEdit = "Edit";
                var brandModel = _brand_Data.GetById((int)id);
                ViewBag.Name = brandModel.Name;
                return View(brandModel);
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
                    _brand_Data.Edit(brandModel);
                    TempData[_tempKey] = $"Succesfully edited Brand: {brandModel.Name.ToUpper()}";
                    return RedirectToAction("Index");
                }
                if (_pim_Helper.PIMOnly_GetAllBrandGenSubNames().Exists(x => x.ToUpper() == brandModel.Name.ToUpper()))
                {
                    ModelState.AddModelError("",duplicateErrorMessage + brandModel.Name);
                    return View(brandModel);
                }
                else
                {
                    _brand_Data.Save(brandModel);
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
            var brandModelList = _brand_Data.GetAll();
            return View(brandModelList);
        }







        /// GeneralType
        /// 
        /// 
        /// 
        [HttpGet]
        public IActionResult AddEditGeneralType(int? id)
        {
            if (id != null)
            {
                ViewBag.AddEdit = "Edit";
                var genTypeModel = _genType_Data.GetById((int)id);
                ViewBag.Name = genTypeModel.TypeName;
                return View(genTypeModel);
            }
            else
            {
                ViewBag.AddEdit = "Add";
                return View();
            }

        }
        [HttpPost]
        public IActionResult AddEditGeneralType(ProductClassModel generalTypeModel)
        {
            if (ModelState.IsValid)
            {
                if (generalTypeModel.Id != null)
                {
                    _genType_Data.Edit(generalTypeModel);
                    TempData[_tempKey] = $"Succesfully edited General Type: {generalTypeModel.TypeName.ToUpper()}.";
                    return RedirectToAction("Index");
                }
                if (_pim_Helper.PIMOnly_GetAllBrandGenSubNames().Exists(x => x.ToUpper() == generalTypeModel.TypeName.ToUpper()))
                {
                    ModelState.AddModelError("", duplicateErrorMessage + generalTypeModel.TypeName);
                    return View(generalTypeModel);
                }
                else
                {
                    _genType_Data.Save(generalTypeModel);
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
            var genTypeModelList = _genType_Data.GetAll();
            return View(genTypeModelList);
        }






        /// SubType
        /// 
        /// 
        /// 
        [HttpGet]
        public IActionResult AddEditSubType(int? id)
        {
            IActionResult result = View();
            if (id != null)
            {
                ViewBag.AddEdit = "Edit";
                var subType = _subType_Data.GetById((int)id);
                ViewBag.Name = subType.SubTypeName;
                result = View(subType);
            }
            else
            {
                ViewBag.AddEdit = "Add";
                result = View();
            }
            ViewBag.GenList = _genType_Data.GetAll();
            return result;
        }
        [HttpPost]
        public IActionResult AddEditSubType(ProductTypeModel subTypeModel)
        {
            IActionResult result = View();
            if (ModelState.IsValid)
            {
                if (subTypeModel.Id != null)
                {
                    _subType_Data.Edit(subTypeModel);
                    TempData[_tempKey] = $"Successfully edited Sub Type: {subTypeModel.SubTypeName}";
                    result = RedirectToAction("SubType_List");
                }
                if (_pim_Helper.PIMOnly_GetAllBrandGenSubNames().Exists(x => x.ToUpper() == subTypeModel.SubTypeName.ToUpper()))
                {
                    ModelState.AddModelError("", duplicateErrorMessage + subTypeModel.SubTypeName);
                    result = View(subTypeModel);
                }
                else
                {
                    _subType_Data.Save(subTypeModel);
                    TempData[_tempKey] = $"Successfully saved Sub Type: {subTypeModel.SubTypeName}";
                    result = RedirectToAction("Index");
                }
            }
            else
            {
                
                result = View(subTypeModel);
            }
            ViewBag.GenList = _genType_Data.GetAll();
            return result;
        }

        public IActionResult SubTypeList()
        {
            var subTypeList = _subType_Data.GetListOfSubWithGenAssociated();
            return View(subTypeList);
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
                result = RedirectToAction("GeneralTypeList");
            }
            else if (deleteModel.Category == "SubType")
            {
                _subType_Data.Delete(deleteModel.Id);
                result = RedirectToAction("SubTypeList");
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
