using DAL.Models;
using Microsoft.EntityFrameworkCore;
//using Microsoft.

namespace DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseAlways<DatabaseContext>());
        }
        public DbSet<TblOrders> TblOrders { get; set; }
        public DbSet<TblWindows> TblWindows { get; set; }
        public DbSet<TblSubElements> TblSubElements { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
