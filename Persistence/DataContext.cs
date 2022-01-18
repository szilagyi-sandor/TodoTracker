namespace Persistence
{
  // CHECKED 1.0
  public class DataContext : IdentityDbContext<AppUser, Role, int>
  {
    public DataContext(DbContextOptions options) : base(options) { }

    public DbSet<Test> Tests => Set<Test>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Role>()
          .HasData(new Role { Id = 2, Name = "Admin", NormalizedName = "ADMIN" });
    }
  }
}
