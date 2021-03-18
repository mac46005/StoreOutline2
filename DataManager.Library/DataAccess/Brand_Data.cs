using DataManager.Library.Helper;
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
        private readonly IConfiguration _config;
        private ISqlDataAccess _sql;
        public Brand_Data(IConfiguration configuration, ISqlDataAccess sql)
        {
            _config = configuration;
            _sql = sql;
        }
        public void Save(BrandModel brandModel)
        {
            _sql.SaveData("dbo.spSaveBrandInfo", new { brandModel.Name,brandModel.Description }, _config.GetSection("Data")[Settings.SO_DB_Key()]/*"SO_DataBase"*/);
        }
        public List<BrandModel> GetAll()
        {
            var brandList = _sql.LoadData<BrandModel, dynamic>("dbo.spGetAllBrands", new { }, _config.GetSection("Data")[Settings.SO_DB_Key()]);
            return brandList;
        }

        public void Edit(BrandModel brandDataModel)
        {
            _sql.SaveData("dbo.spEditBrand",brandDataModel,_config.GetSection("Data")[Settings.SO_DB_Key()]);
        }
        public BrandModel GetById(int id)
        {
            var brandModelList= _sql.LoadData<BrandModel, dynamic>("dbo.spGetBrand_ById", new {id = id}, _config.GetSection("Data")[Settings.SO_DB_Key()]);
            return brandModelList.Find(x => x.Id == id);
        }

        public void Delete(int id)
        {
            _sql.SaveData("dbo.spDeleteBrand",new { Id = id},_config.GetSection("Data")[Settings.SO_DB_Key()]);
        }
        public List<string> GetNames()
        {
            var nameList = _sql.LoadData<string, dynamic>("dbo.spGetBrandNames", new { }, _config.GetSection("Data")[Settings.SO_DB_Key()]);
            return nameList;
        }
    }
}
