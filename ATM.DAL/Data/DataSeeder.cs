using ATM.BL.Models;
using System.Collections.Generic;
using System.Linq;

namespace ATM.DAL.Data
{
    /// <summary>
    /// DataSeeder
    /// </summary>
    public class DataSeeder
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //if there is no data in tables - we fill some initial data

            if (!context.Users.Any())
            {
                var users = new List<User>()
            {
                new User { /*Id = 1,*/UserName="JohnDoe", FirstName="John", LastName = "Doe", Email = "john@john.com", Password="pwd123" },
                new User { /*Id = 2,*/ UserName="MichaelDoe", FirstName="Michael", LastName = "Doe", Email = "michael@michael.com", Password="pwd123" }
            };
                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
