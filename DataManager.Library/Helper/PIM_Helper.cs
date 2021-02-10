using DataManager.Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.Helper
{
    public class PIM_Helper
    {
        private static  IBrand_Data _brand_Data;
        private static IGeneralType_Data _generalType_Data;
        private static ISubType_Data _subType_Data;
        public PIM_Helper(IBrand_Data brand_Data,IGeneralType_Data generalType_Data,ISubType_Data subType_Data)
        {
            _brand_Data = brand_Data;
            _generalType_Data = generalType_Data;
            _subType_Data = subType_Data;
        }
        internal static List<string> ListOfBrandsNames() => _brand_Data.GetNames();
        internal static List<string> ListOfGeneralTypeNames() => _generalType_Data.GetNames();
        internal static List<string> ListOfSubTypeNames() => _subType_Data.GetNames();
    }
}
