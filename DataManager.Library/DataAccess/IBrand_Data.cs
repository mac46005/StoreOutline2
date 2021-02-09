using DataManager.Library.Models;
using System.Collections.Generic;

namespace DataManager.Library.DataAccess
{
    public interface IBrand_Data
    {
        void SaveBrand(BrandModel brandModel);
        List<BrandModel> GetAll();
        BrandModel GetById(int id);
        void EditBrand(BrandModel brandDataModel);
        void Delete(int id);
    }
}