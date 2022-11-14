using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class ToDoListManager : ITodoListService
    {
        IToDoListDal _toDoListDal;
        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }

        public void TAdd(ToDoList t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(ToDoList t)
        {
            throw new NotImplementedException();
        }

        public ToDoList TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ToDoList> TGetList()
        {
            return _toDoListDal.GetList();
        }

        public void TUpdate(ToDoList t)
        {
            throw new NotImplementedException();
        }
    }
}
