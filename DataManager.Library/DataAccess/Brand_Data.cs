using DataManager.Library.Intertnal;
using DataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.DataAccess
{
    public class Brand_Data : IBrand_Data
    {
        string SO_DB_Key = "SO_DB_Key";
        private readonly IConfiguration _configuration;
        private ISqlDataAccess _sql;
        public Brand_Data(IConfiguration configuration, ISqlDataAccess sql)
        {
            _configuration = configuration;
            _sql = sql;
        }
        public void SaveBrand(BrandDataModel brandModel)
        {
            _sql.SaveData("dbo.spSaveBrandInfo", new { brandModel.Name,brandModel.Description }, _configuration.GetSection("Data")[SO_DB_Key]/*"SO_DataBase"*/);
        }
        public List<BrandDataModel> GetAll()
        {
            var brandList = _sql.LoadData<BrandDataModel, dynamic>("dbo.spGetAllBrands", new { }, _configuration.GetSection("Data")[SO_DB_Key]);
            return brandList;
        }

        public BrandDataModel GetById(int id)
        {
            var brandModelList= _sql.LoadData<BrandDataModel, int>("dbo.spGetBrand_ById", id, _configuration.GetSection("Data")[SO_DB_Key]);
            return brandModelList.Find(x => x.Id == id);
        }
    }
}
