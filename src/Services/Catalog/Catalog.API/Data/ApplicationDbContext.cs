namespace Catalog.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Plate> Plates { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Plate>().Ignore(c => c.PromoName);
        //    modelBuilder.Entity<Plate>().Ignore(c => c.HasPromo);
        //}
    }
}
