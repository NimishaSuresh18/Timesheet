using Microsoft.EntityFrameworkCore;
using Tms.Models;

namespace Tms.Data{
    public class TaskContext : DbContext{
        public TaskContext()
        {
        }

        public TaskContext(DbContextOptions<TaskContext>options):base(options)
        {
            
        }
        public DbSet<TaskEntries> TaskEntry{get;set;}
        public DbSet<Assign> Assign{get;set;}
        
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assign>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Assign");
                
                entity.HasKey(e=>e.TaskId);

            });
            modelBuilder.Entity<TaskEntries>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TaskEntries");
                
                entity.HasKey(e=>e.ProjectId);

               
            });
        }
    }
}