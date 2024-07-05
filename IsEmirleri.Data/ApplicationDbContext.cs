using IsEmirleri.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<AppUserType> UserTypes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentFile> CommentFiles { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Mission> Tasks { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<TaskFile> TaskFiles { get; set; }
        public virtual DbSet<TaskHistory> TaskHistories { get; set; }
        public virtual DbSet<MissionStatus> TaskStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<AppUserType>().HasData(
                new AppUserType { Id = 1, Name = "Superadmin" },
                new AppUserType { Id = 2, Name = "Admin" },
                new AppUserType { Id = 3, Name = "User" }
                );
        }
    }
}
