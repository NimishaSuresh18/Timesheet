// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Filters;
// using Tms.Data;
// using Tms.Domain;
// #nullable disable
// namespace AuthorizeFilters{
//     public class CustomAuthorizeFilters : Attribute, IAuthorizationFilter
//     {
//         public void OnAuthorization(AuthorizationFilterContext context)
//         {
//                 if(!context.HttpContext.User.Identity.IsAuthenticated){
//                      context.Result = new RedirectResult("Error");
//                     return;
//                 }
//                 if(!context.HttpContext.User.IsInRole("admin")){
//                     context.Result = new ForbidResult();
//                     return;
//                 }
//             //}
//         }
//         public void OnAuthorizationChallenge(AuthorizationFilterContext context){
//             if(context.Result==null && context.Result is UnauthorizedResult){
//                 context.Result = new ViewResult{
//                     ViewName = "Error"
//                 };
//             }
//         }
//     }
// }



