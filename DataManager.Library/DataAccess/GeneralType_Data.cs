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
        private string SO_DB_Key = nameof(SO_DB_Key).ToString();
        public GeneralType_Data(ISqlDataAccess sql, IConfiguration config)
        {
            _sql = sql;
            _config = config;
        }
        public void Save(GeneralTypeDataModel genType)
        {
            _sql.SaveData("dbo.spSaveGenType", new { typeName = genType.TypeName }, _config.GetSection("Data")[SO_DB_Key]);
        }

        public void GetAll()
        {
            _sql.LoadData<GeneralTypeDataModel, dynamic>("dbo.spGetAllGenType", new { }, _config.GetSection("Data")[SO_DB_Key]);
        }

        public void Edit(GeneralTypeDataModel generalTypeDataModel)
        {
            _sql.SaveData("dbo.spEditGentype", generalTypeDataModel, _config.GetSection("Data")[SO_DB_Key]);
        }

        public void Delete(int id)
        {
            _sql.SaveData("dbo.spDeleteGenType", new { id = id }, _config.GetSection("Data")[SO_DB_Key]);
        }

        public GeneralTypeDataModel GetById(int id)
        {
            var genTypeList = _sql.LoadData<GeneralTypeDataModel, dynamic>("dbo.spGetGenType_ById",new { id = id },_config.GetSection("Data")[SO_DB_Key]);
            return genTypeList.Find(x => x.Id == id);
        }
    }
}
