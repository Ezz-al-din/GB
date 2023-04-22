using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Emit;

namespace WebApplication1.Models
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*this.SeedRoles(builder);*/
        }

        /*private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole() { Name = "SuperAdmin", ConcurrencyStamp= "1" , NormalizedName= "SuperAdmin" },
                    new IdentityRole() { Name = "Admin", ConcurrencyStamp= "2" , NormalizedName= "Admin" },
                    new IdentityRole() { Name = "Supporter", ConcurrencyStamp= "3" , NormalizedName= "Supporter" },
                    new IdentityRole() { Name = "Parent", ConcurrencyStamp= "4" , NormalizedName= "Parent" },
                    new IdentityRole() { Name = "Student", ConcurrencyStamp= "5" , NormalizedName= "Student" }

                );
        }*/
    }
}
