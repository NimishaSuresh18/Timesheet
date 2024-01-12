using Microsoft.AspNetCore.Identity;

namespace Tms.Domain{
    public class ApplicationUser:IdentityUser{
        public string? Name{get;set;}
        public string? ProfilePicture {get;set;}
        public string? HR {get;set;}
    
    }
   
}