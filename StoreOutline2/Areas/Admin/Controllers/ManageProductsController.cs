using DataManager.Library.DataAccess;
using DataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using StoreOutline2.Areas.Admin.Models;
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
        IGeneralDetails_Data _genDetails_Data;
        IProducts_Data _products_Data;
        IBrand_Data _brand_Data;
        IGeneralType_Data _gen_Data;
        ISubType_Data _sub_Data;

        public ManageProductsController(IProducts_Data products_Data
            ,IBrand_Data brand_Data,IGeneralType_Data generalType_Data,ISubType_Data subType_Data,
            IGeneralDetails_Data genDetails_Data)
        {
            _products_Data = products_Data;
            _brand_Data = brand_Data;
            _gen_Data = generalType_Data;
            _sub_Data = subType_Data;
            _genDetails_Data = genDetails_Data;
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
            model.CreateDate = DateTime.Now;
            model.LastModified = DateTime.Now;
            return RedirectToAction(nameof(GeneralDetails),model);
        }
        [HttpGet]
        public IActionResult GeneralDetails(ProductModel model)
        {
            ViewBag.GenData = _gen_Data.GetAll();
            ViewBag.SubData = _sub_Data.GetAll();
            ViewBag.BrandData = _brand_Data.GetAll();
            GeneralProductViewModel vm = new GeneralProductViewModel();
            vm.Product = model;
            return View(vm);
        }
        [HttpPost]
        public IActionResult GeneralDetails(GeneralProductViewModel model)
        {
            _genDetails_Data.Save(model.GenDetails);
            var currentGenDetailsList = _genDetails_Data.GetTop(1);


            //ProductModel productModel = new ProductModel();
            //productModel.ProductName = model.Product.ProductName;
            //productModel.SerialNumber = model.Product.SerialNumber;
            //productModel.Gen_Id = model.Product.Gen_Id;
            //productModel.RetailPrice = model.Product.RetailPrice;
            //productModel.Tax_Id = model.Product.Tax_Id;
            //productModel.QuantityStock = model.Product.QuantityStock;
            //productModel.IsAvailable = model.Product.IsAvailable;
            //productModel.CreateDate = model.Product.CreateDate;
            //productModel.LastModified = model.Product.LastModified;
            model.Product.Gen_Id = currentGenDetailsList[0].Id;
            //  DO SOMETHING...........
            //  I LOVE KAT :)

            return RedirectToAction("ReviewSubmit",model.Product);
        }


        public IActionResult ReviewSubmit(ProductModel model)
        {
            return View(model);
        }




        public IActionResult ReviewSubmit(ProductModel model,bool IsNew = true)
        {
            if (IsNew)
            {
                _products_Data.Save(model);
                return RedirectToAction("Index");
            }

            else
            {
                return View(model);
            }
        }

    }
}
