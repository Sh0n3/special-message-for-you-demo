using DbManagment.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagment.Context
{
    public class DbContextSMFY : DbContext
	{
        public DbContextSMFY(DbContextOptions<DbContextSMFY> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(user => user.UserID);
                entity.Property(user => user.UserID).ValueGeneratedOnAdd();
            });
        }
	}
}
