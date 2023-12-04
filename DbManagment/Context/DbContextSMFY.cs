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
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardTemplate> CardTemplates { get; set; }
        public DbSet<CardImage> CardImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(user => user.UserID);
                entity.Property(user => user.UserID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("Cards");
                entity.HasKey(card => card.CardID);
                entity.Property(card => card.CardID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<CardImage>(entity =>
            {
                entity.ToTable("CardImages");
                entity.HasKey(cardImage => cardImage.CardImageID);
                entity.Property(cardImage => cardImage.CardImageID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<CardTemplate>(entity => 
            {
                entity.ToTable("CardTemplates");
                entity.HasKey(cardTemplate => cardTemplate.CardTemplateID);
                entity.Property(cardTemplate => cardTemplate.CardTemplateID).ValueGeneratedOnAdd();
            });
        }
	}
}
