using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Portfolio
{
    public class PortfolioList :ViewComponent
    {
        //PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDal());
        ProjectManager projectManager = new ProjectManager(new EFProjectDal());
        public IViewComponentResult Invoke()
        {
            //var values = portfolioManager.TGetList();
            //var values2 = projectManager.TGetList();
            var values3 = projectManager.GetListProjectsByCreationDate();
            return View();
        }
    }
}
