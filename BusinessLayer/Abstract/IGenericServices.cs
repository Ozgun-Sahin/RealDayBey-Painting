using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IGenericServices<T>
    {
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> TGetList();
        List<T> TGetListByFilter(int p);
        T TGetById(int id);
    }
}
