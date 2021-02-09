using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.DataAccess
{
    public interface ISubType_Data : IManageData<SubTypeModel>
    {
        List<SubGenModel> GetListOfSubWithGenAssociated();
    }
}
