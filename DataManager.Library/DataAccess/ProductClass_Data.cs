using DataManager.Library.Helper;
using DataManager.Library.Intertnal;
using DataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.DataAccess
{
    public class ProductClass_Data : IProductClass_Data
    {
        private ISqlDataAccess _sql;
        private IConfiguration _config;
        public ProductClass_Data(ISqlDataAccess sql, IConfiguration config)
        {
            _sql = sql;
            _config = config;
        }
        public void Save(ProductClassModel productClass)
        {
            _sql.SaveData("dbo.spSaveProductClass", new { Class = productClass.Class }, _config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public List<ProductClassModel> GetAll()
        {
            var typeList = _sql.LoadData<ProductClassModel, dynamic>("dbo.spGetAllProductClass", new { }, _config.GetSection("Data")[Settings.SO_DB_Key()]);
            return typeList;
        }

        public void Edit(ProductClassModel generalTypeDataModel)
        {
            _sql.SaveData("dbo.spEditProductClass", generalTypeDataModel, _config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public void Delete(int id)
        {
            _sql.SaveData("dbo.spDeleteProductClass", new { id = id }, _config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public ProductClassModel GetById(int id)
        {
            var genTypeList = _sql.LoadData<ProductClassModel, dynamic>("dbo.spGetProductClass_ById",new { id = id },_config.GetSection("Data")[Settings.SO_DB_Key()]);
            return genTypeList.Find(x => x.Id == id);
        }
        public List<string> GetNames()
        {
            var nameList = _sql.LoadData<string, dynamic>("dbo.spGetProductClassNames", new { }, _config.GetSection("Data")[Settings.SO_DB_Key()]);
            return nameList;
        }

        public List<ProductClassModel> GetTop(int x)
        {
            throw new NotImplementedException();
        }
    }
}
