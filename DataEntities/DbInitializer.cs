using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class DbInitializer
    {
        public static void Initialize(PortfolioContext context)
        {
            context.Database.EnsureCreated();

            if (context.UserMessages.Any())
            {
                return;
            }

            var message = new UserMessage[2]
            {
                new UserMessage { FirstName = "Kal", LastName = "Vassar", Subject = "Initialize", Email = "kv19@gmail.com", Message = "fkdsfjlasjfasjfklasdjfjs", DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new UserMessage { FirstName = "Bob", LastName = "David", Subject = "Initialize", Email = "kv19@gmail.com", Message = "dfidsafuhhfhjdsils", DateCreated = DateTime.Now, DateModified = DateTime.Now },
            };

            foreach (UserMessage m in message)
            {
                context.UserMessages.Add(m);
            }
            context.SaveChanges();

            var role = new Role[1]
            {
                new Role { Name = "Admin", DateCreated = DateTime.Now, DateModified = DateTime.Now}
            };

            foreach(Role r in role)
            {
                context.Roles.Add(r);
            }
            context.SaveChanges();

            var starRating = new StarRating[1]
            {
               new StarRating { Rating = 5, DateRated = DateTime.Now } 
            };

            foreach(StarRating sr in starRating)
            {
                context.StarRatings.Add(sr);
            }
            context.SaveChanges();
        }
    }
}

    

