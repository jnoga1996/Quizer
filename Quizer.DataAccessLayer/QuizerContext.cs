using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Quizer.DataAccessLayer.Entities;

namespace Quizer.DataAccessLayer
{
    public class QuizerContext : DbContext
    {
        public QuizerContext(DbContextOptions<QuizerContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Answer>().ToTable("Answers");
            modelBuilder.Entity<Question>().ToTable("Questions");

            modelBuilder.Entity<Category>()
                .HasData(DbInitializer.Categories);

            modelBuilder.Entity<Answer>()
                .HasData(DbInitializer.Answers);

            modelBuilder.Entity<Question>()
                .HasData(DbInitializer.Questions);
        }

    }
}
