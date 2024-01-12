using Microsoft.AspNetCore.Identity;

namespace Tms.Domain{
    public class ApplicationUserRole:IdentityUserRole<string>{
        public int Id{get;set;}
        
        public ApplicationUser? user{get;set;}
        public IdentityRole? Role{get;set;}
     
    
    }
   
}