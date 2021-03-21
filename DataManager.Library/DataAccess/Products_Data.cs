using DataManager.Library.Helper;
using DataManager.Library.Intertnal;
using DataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.DataAccess
{
    public class Products_Data : IProducts_Data
    {
        private readonly IConfiguration _config;
        private ISqlDataAccess _sql;
        public Products_Data(IConfiguration config,ISqlDataAccess sql)
        {
            _config = config;
            _sql = sql;
        }

        public void Delete(int id)
        {
            _sql.SaveData("dbo.DeleteProduct",id,_config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public void Edit(ProductModel type)
        {
            _sql.SaveData("dbo.EditProduct",type,_config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public List<ProductModel> GetAll()
        {
            return _sql.LoadData<ProductModel,dynamic>("dbo.GetAllProducts",new { },_config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public ProductModel GetById(int id)
        {
            return _sql.LoadData<ProductModel, int>("dbo.GetProducts_ById",id,_config.GetSection("Data")[Settings.SO_DB_Key()]).Find(x => x.Id == id);
        }

        public List<string> GetNames()
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetTop(int x)
        {
            throw new NotImplementedException();
        }

        public void Save(ProductModel model)
        {
            _sql.SaveData("dbo.spSaveProduct",model,_config.GetSection("Data")[Settings.SO_DB_Key()]);
        }
    }
}
