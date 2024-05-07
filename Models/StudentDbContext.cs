using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace ReactProject.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext() : base() { }
        public StudentDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SingularizeTableNames();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void SingularizeTableNames(this ModelBuilder modelBuilder)
        {

            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName().ToLower());
                foreach (var property in entity.GetProperties()
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
                {
                    if (property.GetColumnType() == null)
                        property.SetColumnType("decimal(22,6)");
                }
            }
        }


    }
}