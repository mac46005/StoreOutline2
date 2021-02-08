using System;
using System.Collections.Generic;
using System.Text;

namespace DataManager.Library.DataAccess
{
    public interface IManageData<T>
    {
        void Delete(int id);
        void Edit(T type);
        void GetAll();
        void Save(T type);
        T GetById(int id);
    }
}
