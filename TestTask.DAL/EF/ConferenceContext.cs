using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TestTask.DAL.Entities;
namespace TestTask.DAL.EF
{
    public class ConferenceContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionInfo> SectionsInfo { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        
        public ConferenceContext(string connectionString)
            : base(connectionString) { }
    }
}
