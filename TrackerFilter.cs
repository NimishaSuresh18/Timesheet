using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Tms.Data;

namespace filters{
    public class TrackerFilter : IActionFilter
    {
         private readonly AppDbContext context;
         public TrackerFilter(AppDbContext context){
            this.context=context;
         }     
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var data ="";
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            var url =$"{controllerName}/{actionName}";
            if(!string.IsNullOrEmpty(context.HttpContext.Request.QueryString.Value)){
                data = context.HttpContext.Request.QueryString.Value;
            }
            else{
                var userData = context.ActionArguments.FirstOrDefault();
                var stringUserData = JsonConvert.SerializeObject(userData);
                data = stringUserData;
            }
            var userName=context.HttpContext.User.Identity?.Name;
            var ipAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString();
            StoreUserActivity(data, url,userName,ipAddress);
        }
        public void StoreUserActivity(string data, string url,string userName,string ipAddress){
            var userActivity = new UserActivity{
                Data = data,
                Url=url,
                UserName = userName,
                IpAddress = ipAddress,
               

            };
            context.UserActivities.Add(userActivity);
            context.SaveChanges();
        }
         public void OnActionExecuted(ActionExecutedContext context)
        {
            
                  
        }

       
            
        
    }
    
}