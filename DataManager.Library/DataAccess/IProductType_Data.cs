using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.DataAccess
{
    public interface IProductType_Data : IManageData<ProductTypeModel>
    {
        List<TypeClassModel> GetListOfTypeWithClassAssociated();
    }
}
