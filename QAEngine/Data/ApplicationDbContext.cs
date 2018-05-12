using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using QAEngine.Models;
using QAEngine.Models.ThreadModels;
using MySql.Data.EntityFrameworkCore;
namespace QAEngine.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        //Password not on github

        public ApplicationDbContext()
            : base()
        {
        }

        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<AnswerModel> Answers { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

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
            DbContextOptions options = new DbContextOptions<ApplicationDbContext>();


            Password password = new Password();

            string connectionString = "server=127.0.0.1;uid=QAEngine;database=qadatabase;SslMode=none;password=" + password.Pw;

            optionsbuilder.UseMySQL(connectionString);

            MigrationBuilder builder = new MigrationBuilder(connectionString);

            

        }

        // Database working
        public ApplicationDbContext Create()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            return context;
        }
    }

    public class MyMigration : Migration
    {
        public MyMigration()
        {
            
        }

        protected override void Up(MigrationBuilder builder)
        {

        }
    }

    /*
    public abstract class MyMigrationConfiguration<DbContext> : DbMigrationsConfiguration<DbContext>
    {

        private MyMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;  //<<<<<<<<<<<<<<<<<<<
            AutomaticMigrationDataLossAllowed = true;

        }
    }
    */
}
