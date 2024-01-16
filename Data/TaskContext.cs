using Microsoft.EntityFrameworkCore;

namespace AssignTask.Data{
    public class TaskContext : DbContext{
        public TaskContext(DbContextOptions<TaskContext>options):base(options)
        {
            
        }
        public DbSet<Assign>Assigns{get;set;}
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assign>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Assign");
                
                entity.HasKey(e=>e.TaskId);

            });
           
        }
    }
}