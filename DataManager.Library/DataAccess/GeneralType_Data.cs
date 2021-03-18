using DataManager.Library.Helper;
using DataManager.Library.Intertnal;
using DataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.DataAccess
{
    public class GeneralType_Data : IGeneralType_Data
    {
        private ISqlDataAccess _sql;
        private IConfiguration _config;
        public GeneralType_Data(ISqlDataAccess sql, IConfiguration config)
        {
            _sql = sql;
            _config = config;
        }
        public void Save(GeneralTypeModel genType)
        {
            _sql.SaveData("dbo.spSaveGenType", new { typeName = genType.TypeName }, _config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public List<GeneralTypeModel> GetAll()
        {
            var typeList = _sql.LoadData<GeneralTypeModel, dynamic>("dbo.spGetAllGenType", new { }, _config.GetSection("Data")[Settings.SO_DB_Key()]);
            return typeList;
        }

        public void Edit(GeneralTypeModel generalTypeDataModel)
        {
            _sql.SaveData("dbo.spEditGentype", generalTypeDataModel, _config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public void Delete(int id)
        {
            _sql.SaveData("dbo.spDeleteGenType", new { id = id }, _config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public GeneralTypeModel GetById(int id)
        {
            var genTypeList = _sql.LoadData<GeneralTypeModel, dynamic>("dbo.spGetGenType_ById",new { id = id },_config.GetSection("Data")[Settings.SO_DB_Key()]);
            return genTypeList.Find(x => x.Id == id);
        }
        public List<string> GetNames()
        {
            var nameList = _sql.LoadData<string, dynamic>("dbo.spGetGeneralTypeNames", new { }, _config.GetSection("Data")[Settings.SO_DB_Key()]);
            return nameList;
        }
    }
}
