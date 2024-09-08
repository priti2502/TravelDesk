using Microsoft.EntityFrameworkCore;
using TravelDesk.Models;

namespace TravelDesk.Data
{
    public class TravelDeskContext : DbContext
    {
        public TravelDeskContext(DbContextOptions<TravelDeskContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
     
        public DbSet<Project > Projects { get; set; } 
        public DbSet<TravelRequest> TravelRequests { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {





            modelBuilder.Entity<Role>().HasData(
                 new Role { RoleId = 1, RoleName = "Admin", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true },
                 new Role { RoleId = 2, RoleName = "TravelAdmin", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true },
                 new Role { RoleId = 3, RoleName = "Manager", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true },
                 new Role { RoleId = 4, RoleName = "Employee", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true }
             );
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true },
                new Department { DepartmentId = 2, DepartmentName = "HR", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true },
                new Department { DepartmentId = 3, DepartmentName = "SAlES", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true }
               

                );

            modelBuilder.Entity<Project>().HasData(
      new Project { ProjectId = 1, ProjectName = "TravelDesk", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true },
      new Project { ProjectId = 2, ProjectName = "DWF", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true },
      new Project { ProjectId = 3, ProjectName = "IRIS", CreatedBy = 1, CreatedOn = DateTime.Now, IsActive = true }
  );

            modelBuilder.Entity<User>()
                    .HasOne(u => u.Role)
                    .WithMany(r => r.Users)
                    .HasForeignKey(u => u.RoleId)
                    .OnDelete(DeleteBehavior.Restrict); // Or NoAction

            modelBuilder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict); // Or NoAction
            modelBuilder.Entity<User>()
        .HasOne(u => u.Manager)
        .WithMany()
        .HasForeignKey(u => u.ManagerId)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TravelRequest>()
                .HasOne(tr => tr.Project)
                .WithMany(p => p.TravelRequests)
                .HasForeignKey(tr => tr.ProjectId)
                .OnDelete(DeleteBehavior.Restrict); // Or NoAction
            modelBuilder.Entity<TravelRequest>();
    
   






        }


    }
    
}
