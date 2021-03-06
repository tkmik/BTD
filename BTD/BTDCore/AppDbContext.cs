using BTDCore.Models;
using BTDCore.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BTDCore
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserCapability> UserCapabilities { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<TypeOfDocument> TypesOfDocument { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AllDocumentation> AllDocumentations { get; set; }
        public DbSet<TechDocumentation> TechDocumentations { get; set; }
        public DbSet<DesDocumentation> DesDocumentations { get; set; }
        public DbSet<ViewUserDetails> ViewUsersDetails { get; set; }
        public DbSet<SystemEvent> SystemEvents { get; set; }
        public DbSet<EventLog> EventsLog { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<ViewNotice> ViewNotices { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<ViewEventLog> ViewEventsLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();

            var connectionString = config.GetConnectionString("Default");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllDocumentation>(ad =>
            {
                ad.HasNoKey();
                ad.ToView("View_AllDocumentation");
            });
            modelBuilder.Entity<TechDocumentation>(td =>
            {
                td.HasNoKey();
                td.ToView("View_TechDocumentation");
            });
            modelBuilder.Entity<DesDocumentation>(dd =>
            {
                dd.HasNoKey();
                dd.ToView("View_DesDocumentation");
            });
            modelBuilder.Entity<ViewUserDetails>(vu =>
            {
                vu.HasNoKey();
                vu.ToView("View_UserDetails");
            });
            modelBuilder.Entity<ViewNotice>(vu =>
            {
                vu.HasNoKey();
                vu.ToView("View_Notice");
            });
            modelBuilder.Entity<ViewEventLog>(vu =>
            {
                vu.HasNoKey();
                vu.ToView("View_EventLog");
            });

            //    modelBuilder
            //        .Entity<User>()
            //        .Property(e => e.Role)
            //        .HasConversion(
            //            v => v.ToString(),
            //            v => (Role)Enum.Parse(typeof(Role), v));
        }
    }
}
