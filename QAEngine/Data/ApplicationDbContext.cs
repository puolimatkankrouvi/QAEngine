using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QAEngine.Models;
using QAEngine.Models.ThreadModels;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace QAEngine.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base()
        {
        }

        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<AnswerModel> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            
            //Needed?
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserName);
                entity.Property(e => e.PasswordHash);
                entity.Property(e => e.SecurityStamp);
            });

            builder.Entity<QuestionModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Title);
                entity.Property(e => e.Text);
                entity.HasOne(e => e.Poster).WithOne();

            });

            builder.Entity<AnswerModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title);
                entity.Property(e => e.QuestionId).IsRequired();
                entity.Property(e => e.Text);
                entity.HasOne(e => e.Question).WithMany();
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            //Password not on github
            Password password = new Password();
            optionsbuilder.UseMySQL("server=127.0.0.1;user id=QAEngine;database=qadatabase;password=" + password.Pw);
        }

        // Database working
        /*public static ApplicationDbContext Create()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            return context;
        }*/
    }
}
