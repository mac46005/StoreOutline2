 using DataManager.Library.DataAccess;
using DataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreOutline2.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        ILogger<ManageProductsController> _logger;

        public ManageProductsController(ILogger<ManageProductsController> logger, IProducts_Data products_Data
            ,IBrand_Data brand_Data,IGeneralType_Data generalType_Data,ISubType_Data subType_Data,
            IGeneralDetails_Data genDetails_Data)
        {
            _products_Data = products_Data;
            _brand_Data = brand_Data;
            _gen_Data = generalType_Data;
            _sub_Data = subType_Data;
            _genDetails_Data = genDetails_Data;
            _logger = logger;
        }
        static string _address = "Admin/ManageProducts/";

        public IActionResult Index()
        {
            _logger.LogInformation(_address + nameof(Index));
            return View();
        }
        [HttpGet]
        public IActionResult AddNewProduct()
        {
            _logger.LogInformation(_address + nameof(AddNewProduct) + "[GET]");
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProduct(ProductModel model)
        {
            _logger.LogInformation(_address + nameof(AddNewProduct) + "[POST]");
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
            ProductCreationViewModel vm = new ProductCreationViewModel();
            vm.Product = model;
            return View(vm);
        }
        [HttpPost]
        public IActionResult GeneralDetails(ProductCreationViewModel model)
        {

            return RedirectToAction(nameof(ReviewSubmit), model);
        }


        public IActionResult ReviewSubmit(ProductCreationViewModel model)
        {
            return View(model);
        }




        public IActionResult ReviewSubmit(ProductCreationViewModel model,bool IsNew = true)
        {
            if (IsNew)
            {
                ////
                ///Will make a system for saving images on a new view and Controller methods.




                //_products_Data.Save(model);
                
                // Save gen details
                _genDetails_Data.Save(model.GenDetails);

                // Retrieves gen detail just saved
                var topGen = _genDetails_Data.GetTop(1)[0];

                // Retrieves genDetails id for product.Gen_Id
                model.Product.Gen_Id = topGen.Id;

                // Saves the product
                _products_Data.Save(model.Product);

                //Returns to Admin Home
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

    }
}
