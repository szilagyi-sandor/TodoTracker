namespace Persistence
{
  // CHECKED 1.0
  public class Seed
  {
    public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
    {
      if (!userManager.Users.Any())
      {
        var adminUser = new AppUser
        {
          UserName = "adminuser@test.com",
          Email = "adminuser@test.com",
          DisplayName = "Admin User",
          CreatedAt = new DateTime(2021, 07, 07),
          Status = (int)UserStatusTypes.approved
        };

        await userManager.CreateAsync(adminUser, "Pa$$w0rd");
        await userManager.AddToRolesAsync(adminUser, new[] { "Admin" });

        var testUser = new AppUser
        {
          UserName = "testuser@test.com",
          Email = "testuser@test.com",
          DisplayName = "Test User",
          CreatedAt = new DateTime(2021, 08, 08),
          Status = (int)UserStatusTypes.pending
        };

        await userManager.CreateAsync(testUser, "Pa$$w0rd");
      }

      if (context.Tests.Any())
      {
        return;
      }

      var tests = new List<Test>
        {
          new Test
            {
              Title = "Test 1",
              Date = DateTime.Now.AddMonths(-2),
            },
          new Test
            {
              Title = "Test 2",
              Date = DateTime.Now.AddMonths(-1),
            },
          new Test
            {
              Title = "Test 3",
              Date = DateTime.Now.AddMonths(1),
            },
          new Test
            {
              Title = "Test 4",
              Date = DateTime.Now.AddMonths(2),
            },
          new Test
            {
              Title = "Test 5",
              Date = DateTime.Now.AddMonths(3),
            },
          new Test
            {
              Title = "Test 6",
              Date = DateTime.Now.AddMonths(4),
            },
          new Test
            {
              Title = "Test 7",
              Date = DateTime.Now.AddMonths(5),
            },
          new Test
            {
              Title = "Test 8",
              Date = DateTime.Now.AddMonths(6),
            },
          new Test
            {
              Title = "Test 9",
              Date = DateTime.Now.AddMonths(7),
            },
          new Test
            {
              Title = "Test 10",
              Date = DateTime.Now.AddMonths(8),
            }
        };

      await context.Tests.AddRangeAsync(tests);

      await context.SaveChangesAsync();
    }
  }
}
