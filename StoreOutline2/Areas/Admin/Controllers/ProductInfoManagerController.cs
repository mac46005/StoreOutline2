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
        private IProductClass_Data _productClass_Data;
        private IProductType_Data _productType_Data;
        private IPIM_Helper _pim_Helper;
        public ProductInfoManagerController(IConfiguration config,
            IBrand_Data brand_Data, IProductClass_Data genTypeData, IProductType_Data subType_Data,
            IPIM_Helper pim_Helper)
        {
            _config = config;
            _brand_Data = brand_Data;
            _productClass_Data = genTypeData;
            _productType_Data = subType_Data;
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
                if (_pim_Helper.PIMOnly_GetAllBrandClassTypeNames().Exists(x => x.ToUpper() == brandModel.Name.ToUpper()))
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







        /// Product Class
        /// 
        /// 
        /// 
        [HttpGet]
        public IActionResult AddEditProductClass(int? id)
        {
            if (id != null)
            {
                ViewBag.AddEdit = "Edit";
                var prodClassModel = _productClass_Data.GetById((int)id);
                ViewBag.Name = prodClassModel.Class;
                return View(prodClassModel);
            }
            else
            {
                ViewBag.AddEdit = "Add";
                return View();
            }

        }
        [HttpPost]
        public IActionResult AddEditProductClass(ProductClassModel productClassModel)
        {
            if (ModelState.IsValid)
            {
                if (productClassModel.Id != null)
                {
                    _productClass_Data.Edit(productClassModel);
                    TempData[_tempKey] = $"Succesfully edited Product Class: {productClassModel.Class.ToUpper()}.";
                    return RedirectToAction("Index");
                }
                if (_pim_Helper.PIMOnly_GetAllBrandClassTypeNames().Exists(x => x.ToUpper() == productClassModel.Class.ToUpper()))
                {
                    ModelState.AddModelError("", duplicateErrorMessage + productClassModel.Class);
                    return View(productClassModel);
                }
                else
                {
                    _productClass_Data.Save(productClassModel);
                    TempData[_tempKey] = $"Successfully added new Product Class: {productClassModel.Class.ToUpper()}.";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(productClassModel);
            }
        }

        public IActionResult ProductClassList()
        {
            var productClassModelList = _productClass_Data.GetAll();
            return View(productClassModelList);
        }






        /// Product Type
        /// 
        /// 
        /// 
        [HttpGet]
        public IActionResult AddEditProductType(int? id)
        {
            IActionResult result = View();
            if (id != null)
            {
                ViewBag.AddEdit = "Edit";
                var productType = _productType_Data.GetById((int)id);
                ViewBag.Name = productType.Type;
                result = View(productType);
            }
            else
            {
                ViewBag.AddEdit = "Add";
                result = View();
            }
            ViewBag.classList = _productClass_Data.GetAll();
            return result;
        }
        [HttpPost]
        public IActionResult AddEditProductType(ProductTypeModel productTypeModel)
        {
            IActionResult result = View();
            if (ModelState.IsValid)
            {
                if (productTypeModel.Id != null)
                {
                    _productType_Data.Edit(productTypeModel);
                    TempData[_tempKey] = $"Successfully edited Product Type: {productTypeModel.Type}";
                    result = RedirectToAction("ProductType_List");
                }
                if (_pim_Helper.PIMOnly_GetAllBrandClassTypeNames().Exists(x => x.ToUpper() == productTypeModel.Type.ToUpper()))
                {
                    ModelState.AddModelError("", duplicateErrorMessage + productTypeModel.Type);
                    result = View(productTypeModel);
                }
                else
                {
                    _productType_Data.Save(productTypeModel);
                    TempData[_tempKey] = $"Successfully saved Product Type: {productTypeModel.Type}";
                    result = RedirectToAction("Index");
                }
            }
            else
            {
                
                result = View(productTypeModel);
            }
            ViewBag.ClassList = _productClass_Data.GetAll();
            return result;
        }

        public IActionResult ProductTypeList()
        {
            var productTypeList = _productType_Data.GetListOfTypeWithClassAssociated();
            return View(productTypeList);
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
                _productClass_Data.Delete(deleteModel.Id);
                result = RedirectToAction("GeneralTypeList");
            }
            else if (deleteModel.Category == "SubType")
            {
                _productType_Data.Delete(deleteModel.Id);
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
