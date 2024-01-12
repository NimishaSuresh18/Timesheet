using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tms.Domain;
using Tms.Models;

namespace Tms.Data{
    public class AppDbContext : IdentityDbContext<ApplicationUser>{
         private readonly DbContextOptions _options;

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){
            _options = options; 
        }
        public DbSet<UserActivity> UserActivities{get;set;}
        public DbSet<TaskEntries> TaskEntry {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }    
       
    }










    
         public class UserActivity{
        public int Id{get;set;}
        public string? Data{get; set;}
        public string? Url{get; set;}
        public string? Link {get;set;}
        public string? UserName{get; set;}
        public string? IpAddress{get; set;}
        public DateTime Timeout {get;set;} = DateTime.Now;
        

    }
}