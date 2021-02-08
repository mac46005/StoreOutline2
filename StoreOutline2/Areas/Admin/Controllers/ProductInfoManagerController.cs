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
        public ProductInfoManagerController(IConfiguration config,IBrand_Data brand_Data)
        {
            _config = config;
            _brand_Data = brand_Data;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddEditBrand()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddEditBrand(int id)
        {
            var brandDataModel = _brand_Data.GetById(id);
            return View(new BrandModel { Id = brandDataModel.Id,Name = brandDataModel.Name,Description = brandDataModel.Description });
        }
        [HttpPost]
        public IActionResult AddEditBrand(BrandModel brandModel)
        {
            if (ModelState.IsValid)
            {
                _brand_Data.SaveBrand(new BrandDataModel { Name = brandModel.Name,Description = (brandModel.Description ?? string.Empty) });
                TempData[_tempKey] = $"{brandModel.Name} has been added to Brands List";
                return RedirectToAction("Index");
            }
            else
            {
                return View(brandModel);
            }
        }
        public IActionResult AddEditGeneralType()
        {
            return View();
        }

        public IActionResult AddEditSubType()
        {
            return View();
        }


        public IActionResult BrandList()
        {
            List<BrandModel> brandModelList = new List<BrandModel>();
            var brandDataModelList = _brand_Data.GetAll();
            foreach (var brand in brandDataModelList)
            {
                brandModelList.Add(new BrandModel { Id = brand.Id,Name = brand.Name,Description = brand.Description });
            }
            return View(brandModelList);
        }


    }
}
