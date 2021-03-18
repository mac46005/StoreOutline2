using DataManager.Library.Helper;
using DataManager.Library.Intertnal;
using DataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.DataAccess
{
    public class SubType_Data : ISubType_Data
    {
        private IConfiguration _config;
        private ISqlDataAccess _sql;
        public SubType_Data(IConfiguration config,ISqlDataAccess sql)
        {
            _config = config;
            _sql = sql;
        }
        public void Delete(int id)
        {
            _sql.SaveData("dbo.spDeleteSubtype",new { Id = id }, _config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public void Edit(SubTypeModel type)
        {
            _sql.SaveData("dbo.EditSubType",type,_config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public List<SubTypeModel> GetAll()
        {
            var stList = _sql.LoadData<SubTypeModel, dynamic>("dbo.spGetAllSubType",new { },_config.GetSection("Data")[Settings.SO_DB_Key()]);
            return stList;
        }

        public SubTypeModel GetById(int id)
        {
            var stList = _sql.LoadData<SubTypeModel,dynamic>("dbo.spGetSubType_ById",new { Id= id },_config.GetSection("Data")[Settings.SO_DB_Key()]);
            return stList.Find(x => x.Id == id);
        }

        public void Save(SubTypeModel type)
        {
            _sql.SaveData("dbo.spSaveSubType", new { SubTypeName = type.SubTypeName, GeneralType_Id = type.GeneralType_Id }, _config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public List<SubGenModel> GetListOfSubWithGenAssociated()
        {
            var subGenList = _sql.LoadData<SubGenModel, dynamic>("dbo.spGetSubWithGenAssociated",new { },_config.GetSection("Data")[Settings.SO_DB_Key()]);
            return subGenList;
        }

        public List<string> GetNames()
        {
            var nameList = _sql.LoadData<string, dynamic>("dbo.spGetSubTypeNames",new { },_config.GetSection("Data")[Settings.SO_DB_Key()]);
            return nameList;
        }
    }
}
