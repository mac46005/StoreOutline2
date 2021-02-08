using DataManager.Library.Models;
using System.Collections.Generic;

namespace DataManager.Library.DataAccess
{
    public interface IBrand_Data
    {
        void SaveBrand(BrandDataModel brandModel);
        List<BrandDataModel> GetAll();
        BrandDataModel GetById(int id);
        void EditBrand(BrandDataModel brandDataModel);
        void Delete(int id);
    }
}