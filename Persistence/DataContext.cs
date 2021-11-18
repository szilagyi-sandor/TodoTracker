namespace Persistence;

public class DataContext : IdentityDbContext<AppUser>
{
  public DataContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<Test> Tests => Set<Test>();
}
