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
        IProductClass_Data _gen_Data;
        IProductType_Data _sub_Data;
        ILogger<ManageProductsController> _logger;
        LoggingHelper<ManageProductsController> _logging;

        public ManageProductsController(ILogger<ManageProductsController> logger, IProducts_Data products_Data
            , IBrand_Data brand_Data, IProductClass_Data generalType_Data, IProductType_Data subType_Data,
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

        public IActionResult Index()
        {
            _logging.CurrentAddress = nameof(Index);
            _logging.Address();
            return View();
        }





        [HttpGet]
        public IActionResult NewProductInformation()
        {
            _logging.CurrentAddress = nameof(NewProductInformation) + "[GET]";
            _logging.InformationLog("Product instance instantiated.");
            return View();
        }
    }
}
