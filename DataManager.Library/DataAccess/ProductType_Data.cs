using DataManager.Library.Helper;
using DataManager.Library.Intertnal;
using DataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.DataAccess
{
    public class ProductType_Data : IProductType_Data
    {
        private IConfiguration _config;
        private ISqlDataAccess _sql;
        public ProductType_Data(IConfiguration config,ISqlDataAccess sql)
        {
            _config = config;
            _sql = sql;
        }
        public void Delete(int id)
        {
            _sql.SaveData("dbo.spDeleteProductType",new { Id = id }, _config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public void Edit(ProductTypeModel type)
        {
            _sql.SaveData("dbo.EditProductType",type,_config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public List<ProductTypeModel> GetAll()
        {
            var stList = _sql.LoadData<ProductTypeModel, dynamic>("dbo.spGetAllProductType",new { },_config.GetSection("Data")[Settings.SO_DB_Key()]);
            return stList;
        }

        public ProductTypeModel GetById(int id)
        {
            var stList = _sql.LoadData<ProductTypeModel,dynamic>("dbo.spGetProductType_ById",new { Id= id },_config.GetSection("Data")[Settings.SO_DB_Key()]);
            return stList.Find(x => x.Id == id);
        }

        public void Save(ProductTypeModel type)
        {
            _sql.SaveData("dbo.spSaveProductType", new { SubTypeName = type.Type, GeneralType_Id = type.GeneralType_Id }, _config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public List<TypeClassModel> GetListOfSubWithGenAssociated()
        {
            var subGenList = _sql.LoadData<TypeClassModel, dynamic>("dbo.spGetTypeWithClassAssociated",new { },_config.GetSection("Data")[Settings.SO_DB_Key()]);
            return subGenList;
        }

        public List<string> GetNames()
        {
            var nameList = _sql.LoadData<string, dynamic>("dbo.spGetProductTypeNames",new { },_config.GetSection("Data")[Settings.SO_DB_Key()]);
            return nameList;
        }

        public List<ProductTypeModel> GetTop(int x)
        {
            throw new NotImplementedException();
        }
    }
}
