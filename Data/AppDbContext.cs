using Microsoft.EntityFrameworkCore;
using MyProject.Models;
namespace MyProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Contact> ContactUs { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Fact> Facts { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<skills> Skills { get; set; }
        public DbSet<Services> Services { get; set; }



    }
}