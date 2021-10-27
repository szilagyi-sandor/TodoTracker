using System;
using Domain;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
  public class Seed
  {
    public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
    {
      if (!userManager.Users.Any())
      {
        var users = new List<AppUser>{
          new AppUser {
            UserName = "TestUser",
            Email = "test@test.com",
            DisplayName = "Test User"
          }
        };

        foreach (var user in users)
        {
          await userManager.CreateAsync(user, "Pa$$w0rd");
        }
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