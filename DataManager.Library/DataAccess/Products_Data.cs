using DataManager.Library.Intertnal;
using DataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.DataAccess
{
    public class Products_Data : IProduct_Data
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
            throw new NotImplementedException();
        }

        public void Edit(ProductModel type)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetNames()
        {
            throw new NotImplementedException();
        }

        public void Save(ProductModel type)
        {
            throw new NotImplementedException();
        }
    }
}
