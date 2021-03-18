using DataManager.Library.DataAccess;
using DataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreOutline2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class ManageProductsController : Controller
    {

        IProducts_Data _products_Data;
        IBrand_Data _brand_Data;
        IGeneralType_Data _gen_Data;
        ISubType_Data _sub_Data;

        public ManageProductsController(IProducts_Data products_Data
            ,IBrand_Data brand_Data,IGeneralType_Data generalType_Data,ISubType_Data subType_Data)
        {
            _products_Data = products_Data;
            _brand_Data = brand_Data;
            _gen_Data = generalType_Data;
            _sub_Data = subType_Data;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddNewProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProduct(ProductModel model)
        {
            return RedirectToAction(nameof(GeneralDetails),model);
        }
        [HttpGet]
        public IActionResult GeneralDetails(ProductModel model)
        {
            ViewBag.GenData = _gen_Data.GetAll();
            ViewData["SubData"] = _sub_Data.GetAll();
            ViewData["BrandData"] = _brand_Data.GetAll();
            return View();
        }
        //public IActionResult GeneralDetails()
        //{

        //}

    }
}
