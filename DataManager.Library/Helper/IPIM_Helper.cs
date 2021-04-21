using System.Collections.Generic;

namespace DataManager.Library.Helper
{
    public interface IPIM_Helper
    {
        List<string> PIMOnly_GetAllBrandClassTypeNames();
        //bool CheckForDuplicate(List<string> list, string value);
    }
}