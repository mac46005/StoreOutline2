using DataManager.Library.DataAccess;
using DataManager.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreOutline2.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        LoggingHelper<ManageProductsController> _logging;

        public ManageProductsController(ILogger<ManageProductsController> logger, IProducts_Data products_Data
            , IBrand_Data brand_Data, IGeneralType_Data generalType_Data, ISubType_Data subType_Data,
            IGeneralDetails_Data genDetails_Data)
        {
            _products_Data = products_Data;
            _brand_Data = brand_Data;
            _gen_Data = generalType_Data;
            _sub_Data = subType_Data;
            _genDetails_Data = genDetails_Data;
            _logger = logger;
            _logging = new LoggingHelper<ManageProductsController>("Admin/ManageProducts/", _logger);
        }
        static string _address = "Admin/ManageProducts/";

        public IActionResult Index()
        {
            _logging.CurrentAddress = nameof(Index);
            _logging.Address();
            return View();
        }
        [HttpGet]
        public IActionResult AddNewProduct()
        {
            _logging.CurrentAddress = nameof(AddNewProduct) + "[GET]";
            _logging.InformationLog("Product instance instantiated.");
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProduct(ProductModel model)
        {
            _logging.CurrentAddress = nameof(AddNewProduct) + "[POST]";
            _logging.InformationLog("Sending ProductModel to GeneralDetails for further processing.");


            model.CreateDate = DateTime.Now;
            model.LastModified = DateTime.Now;
            return RedirectToAction(nameof(GeneralDetails), model);
        }

        [HttpGet]
        public IActionResult GeneralDetails(ProductModel model)
        {
            _logging.CurrentAddress = nameof(GeneralDetails) + "[GET]";

            try
            {
                ViewBag.GenData = _gen_Data.GetAll();
                ViewBag.SubData = _sub_Data.GetAll();
                ViewBag.BrandData = _brand_Data.GetAll();
            }
            catch (SqlException ex)
            {

                _logging.ErrorList(ex.Message);
            }
            TempData["ProductObj"] = (ProductModel)model;
            return View();
        }

        [HttpPost]
        public IActionResult GeneralDetails(ProductCreationViewModel model)
        {
            _logging.CurrentAddress = nameof(GeneralDetails) + "[POST]";


            model.Product = (ProductModel)TempData["ProductObj"];
            return RedirectToAction(nameof(ReviewSubmit), model);
        }

        [HttpGet]
        public IActionResult ReviewSubmit(ProductCreationViewModel model)
        {
            _logging.CurrentAddress = nameof(ReviewSubmit) + "[GET]";
            return View(model);
        }


        [HttpPost]
        public IActionResult ReviewSubmit(ProductModel product, string action)
        {
            _logging.CurrentAddress = nameof(ReviewSubmit) + "[POST]";
            _logging.Address();


            IActionResult result = View(product);
            

            try
            {
                switch (action)
                {
                    case "Submit":
                        _genDetails_Data.Save(product.GeneralDetails);
                        product.Gen_Id = _genDetails_Data.GetTop(1)[0].Id;
                        _products_Data.Save(product);
                        result = RedirectToAction();
                        break;
                    default:
                        break;
                }
            }
            catch (SqlException ex)
            {
                _logging.ErrorList(ex.Message);
                throw;
            }


            return result;
        }

    }
}
