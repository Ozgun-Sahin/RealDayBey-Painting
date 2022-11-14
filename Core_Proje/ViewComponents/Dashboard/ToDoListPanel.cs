using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class ToDoListPanel :ViewComponent
    {
        ToDoListManager toDoListManager = new ToDoListManager(new EFToDoListDal());

        public IViewComponentResult Invoke()
        {
            var values = toDoListManager.TGetList();

            return View(values);
        }
    }
}
