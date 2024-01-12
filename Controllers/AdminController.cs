using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tms.Data;
using Tms.Domain;
using Tms.Models;

namespace Tms.Controllers{
   
    public class AdminController: Controller{
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;    
        public AdminController(UserManager<ApplicationUser> userManager,AppDbContext _context,RoleManager<IdentityRole> roleManager,IWebHostEnvironment hostEnvironment)
        {
            this.userManager=userManager;
            this._context=_context;
            this.roleManager=roleManager;
            this._hostEnvironment = hostEnvironment;
            
        }
            public IActionResult Display(){
            return View();
        }
          public IActionResult Times(){
            return View();
        }
         public async Task<IActionResult> Profile(){
             
            string? mail = User.Identity?.Name;
            var details = await _context.Users.ToListAsync();
            var role = await _context.Roles.ToListAsync();
            var us=await _context.UserRoles.ToListAsync();
            IEnumerable <ApplicationUser> users = from e in details where e.UserName==mail select e;
          // IEnumerable <ApplicationUser> users =from e in details from a in us where e.Id==a.UserId && from select e;
        
             return View(users);
        }
        
          public async Task<IActionResult> Team(){
            if(User.IsInRole("admin")){
            string? mail = User.Identity?.Name;
            var details = await _context.Users.ToListAsync();
            IEnumerable <ApplicationUser> users = from e in details where e.UserName!=mail select e ;
             return View(users);
            }
            else{
                var details = await _context.Users.ToListAsync();
            IEnumerable <ApplicationUser> users = from  e in details where e.UserName!="admin@sys.com" && e.UserName!=User.Identity?.Name select e;
            return View(users);

            }
        }
        
         public ActionResult Delete(string? id)
        {
            if(id==null){
                return NotFound();
            }
            var employee = _context.Users.SingleOrDefault(u=>u.Id==id);
            if(employee!=null){
                _context.Users.Remove(employee);
                _context.SaveChanges();
            }
            return RedirectToAction("Team");
        }

}

       


    
        
    }
