using System.Data;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Tms.Data;
using Tms.Domain;
using Tms.Models;

public class TimesheetController : Controller{

   public IConfiguration Configuration{get;}
   public SqlConnection sqlConnection;
   private readonly AppDbContext _context;
 
   public TimesheetController(IConfiguration configuration,AppDbContext _context){
  
    Configuration=configuration;
    this._context=_context;

    
   }
public ActionResult Attendance(){
    return View();
}

[HttpGet]
public IActionResult Duallogin(){
    return View();
}

[HttpGet]
    public IActionResult Tracker(string uname)
    {
        var username=from e in _context.UserActivities select e;
        if(!String.IsNullOrEmpty(uname)){
            
            username = username.Where(course=>course.UserName!.Contains(uname));
            if(username!=null){
                return View(username.ToList());
            }
        }
        return View(username!.ToList());
    }


        
             
}