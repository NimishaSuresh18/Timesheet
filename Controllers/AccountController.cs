using Microsoft.AspNetCore.Mvc;

namespace Tms.Controllers{
    public class AccountController : Controller{
        public ActionResult AccessDenied(){
            return View();
        }
    }
}