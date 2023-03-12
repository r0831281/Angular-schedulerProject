using Microsoft.AspNetCore.Authorization.Infrastructure;
using StaffSchedulerApi.Data;
using StaffSchedulerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StaffSchedulerApi.Services
{
    public class DBinitializer
    {

        public static class DBInitializer
        {
            public static void Initialize(ScheduleContext context)
            {
                context.Database.EnsureCreated();

                // Look for any products.
                if (context.roles.Any())
                {
                    return;   // DB has been seeded
                }
                context.AddRange(
                     new Role()
                     {
                          RoleId = 2,
                          RoleName = "Admin"
                     },
                     new Role()
                     {
                         RoleId = 1,
                         RoleName = "User"
                     },
                     new Role()
                     {
                         RoleId = 3,
                         RoleName = "Student"
                     },
                     new Role()
                     {
                         RoleId = 4,
                         RoleName = "Planner"
                     }
                );

                context.AddRange(
                            new User
                            {
                                UserName = "micclo",
                                Password = "test",
                                Email = "test@test",
                                FirstName = "aaa",
                                LastName = "bbb",


                            },
                            new User
                            {
                                UserName = "jos",
                                Password = "test",
                                RoleId = 2,
                                Email = "test@test",
                                FirstName = "aaa",
                                LastName = "bbb",
                            });

                context.SaveChanges();
            }
        }
    }
}
