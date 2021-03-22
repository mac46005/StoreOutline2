using DataManager.Library.Helper;
using DataManager.Library.Intertnal;
using DataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.DataAccess
{
    public class GeneralDetails_Data : IGeneralDetails_Data
    {

        private readonly IConfiguration _config;
        private ISqlDataAccess _sql;
        public GeneralDetails_Data(IConfiguration config, ISqlDataAccess sql)
        {
            _config = config;
            _sql = sql;
        }

        public void Delete(int id)
        {
            _sql.SaveData("",new { id },_config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public void Edit(GeneralDetailsModel type)
        {
            _sql.SaveData("",type,_config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public List<GeneralDetailsModel> GetAll()
        {
            return _sql.LoadData<GeneralDetailsModel, dynamic>("",new { },_config.GetSection("Data")[Settings.SO_DB_Key()]);
        }

        public GeneralDetailsModel GetById(int id)
        {
            return _sql.LoadData<GeneralDetailsModel, dynamic>("",new { id },_config.GetSection("Data")[Settings.SO_DB_Key()]).Find(x => x.Id == id);
        }

        public List<string> GetNames()
        {
            throw new NotImplementedException();
        }

        public void Save(GeneralDetailsModel type)
        {
            _sql.SaveData("",type,_config.GetSection("Data")[Settings.SO_DB_Key()]);
        }
        public List<GeneralDetailsModel> GetTop(int x)
        {
            return _sql.LoadData<GeneralDetailsModel,int>("",x,_config.GetSection("Data")[Settings.SO_DB_Key()]);
        }
    }
}
