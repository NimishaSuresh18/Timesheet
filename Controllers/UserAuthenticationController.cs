using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Tms.Domain;
using Tms.Models;
using Tms.Repositories.Abstract;

namespace Tms.Controllers{
    public class UserAuthenticationController : Controller{
        private readonly IUserAuthenticationService _service;
       
        public UserAuthenticationController(IUserAuthenticationService service){
            this._service=service;
           
        }
        public IActionResult Registration(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model){
            if(!ModelState.IsValid)
                return View(model);
            
                var result=await _service.RegistrationAsync(model);
                TempData["msg"]=result.Message;
                return RedirectToAction(nameof(Registration));       
        }
        [HttpGet ]
        public IActionResult Login(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLogin model){
            if(!ModelState.IsValid){
                return View(model);
            }
            var result = await _service.LoginAsync(model);         
            if(result.StatusCode==1)
            {
                return RedirectToAction("Display","Dashboard");
                }
            else{
                TempData["msg"] =result.Message;
                return RedirectToAction(nameof(Login));
            }
        }
        [Authorize]
        public async Task<IActionResult> Logout(){
          string? name = User.Identity?.Name;
          Loggerclass.logtimein(name);
          await _service.LogoutAsync();
          return RedirectToAction(nameof(Login));
        }
       
        public IActionResult Error()
    {
        ErrorViewModel error = new ErrorViewModel();
        return View(error);
    }
        
       
       
        
    
      

        
    }
}