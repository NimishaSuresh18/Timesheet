//using AuthorizeFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tms.Controllers{
    //[CustomAuthorizeFilters]
    [Authorize]
    public class DashboardController : Controller{
       //[CustomAuthorizeFilters]
        public IActionResult Display(){
            return View();
        }      
    }
}