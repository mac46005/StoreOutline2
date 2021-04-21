using DataManager.Library.DataAccess;
using DataManager.Library.Intertnal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.Helper
{
    public class PIM_Helper : IPIM_Helper
    {
        private IConfiguration _config;
        private ISqlDataAccess _sql;
        public PIM_Helper(IConfiguration config, ISqlDataAccess sql)
        {
            _config = config;
            _sql = sql;
        }
        public List<string> PIMOnly_GetAllBrandClassTypeNames()
        {
            var stringList = _sql.LoadData<string, dynamic>("spPIMOnly_GetAllBrandTypeClassNames", new { }, _config.GetSection("Data")[Settings.SO_DB_Key()]);
            return stringList;
        }

        //public bool CheckForDuplicate(List<string> list,string value)
        //{
        //    bool isDuplicate = false;
        //    foreach (var item in list)
        //    {
        //        if (value == item)
        //        {
        //            isDuplicate = true;
        //        }
        //    }
        //    return isDuplicate;
        //}
    }
}
