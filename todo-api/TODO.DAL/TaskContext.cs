using Microsoft.EntityFrameworkCore;
using System;
using TODO.Model;

namespace TODO.DAL
{
    /// <summary>
    /// Context class for Task
    /// </summary>
    public class TaskContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public TaskContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Task> Tasks { get; set; }

        /// <summary>
        /// Seed Data for Task Table
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Task>().HasData(
            new Task
            {
                Id = 1,
                Name = "Shopping",
                Priority = "Low",
                DueDate = DateTime.Today.AddDays(2)
            },
            new Task
            {
                Id = 2,
                Name = "Meeting",
                Priority = "High",
                DueDate = DateTime.Today
            },
            new Task
            {
                Id = 3,
                Name = "Health Checkup",
                Priority = "Medium",
                DueDate = DateTime.Today.AddDays(1)
            });
        }
    }
}
