using StaffSchedulerApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StaffSchedulerApi.Models
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

                Role adminRole = new Role()
                {
                    role = "admin"
                };
                context.roles.Add(adminRole);
                context.SaveChanges();
            }
        }
    }
}
