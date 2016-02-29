namespace DynamicBar.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.DBEntities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DynamicBar.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DynamicBar.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!(context.Users.Any(u => u.UserName == "Rene")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "Rene", Email="rene.eppensteiner@gmail.com" };
                userManager.Create(userToInsert, "Password@123");
            }

            ApplicationUser user = context.Users.First();

            context.Places.AddOrUpdate(
                p => p.Title,
                new Place { Title = "Table 1", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 2 },
                new Place { Title = "Table 2", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 4 },
                new Place { Title = "Table 3", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 4 },
                new Place { Title = "Table 4", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 2 },
                new Place { Title = "Table 5", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 6 },
                new Place { Title = "Table 6", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 10 },
                new Place { Title = "Table 7", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 9 },
                new Place { Title = "Table 8", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 8 },
                new Place { Title = "Table 9", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 3 },
                new Place { Title = "Table 10", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 2 }
            );

            context.ProductTypes.AddOrUpdate(p => p.Title,

                new ProductType { Title = "Bier", Description = "Bier ist super!", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductType { Title = "Wein", Description = "Wein ist geil!", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductType { Title = "Cocktail", Description = "Für Frauen!", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductType { Title = "Whiskey", Description = "Whiskey ist super!", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductType { Title = "Likör", Description = "Likör ist gefährlich!", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductType { Title = "Limonade", Description = "Süß", CreatedById = user.Id, DateCreated = DateTime.Now }
            );

            var bierCatId = context.ProductTypes.Where(t => t.Title == "Bier").Select(t => t.ProductTypeId).FirstOrDefault();

            context.OrderStates.AddOrUpdate(o => o.Title,

                new OrderState { Title = "Ordered", Description = "Ordered", CreatedById = user.Id, DateCreated = DateTime.Now },
                new OrderState { Title = "Delivered", Description = "Ordered", CreatedById = user.Id, DateCreated = DateTime.Now },
                new OrderState { Title = "Paid", Description = "Ordered", CreatedById = user.Id, DateCreated = DateTime.Now }
            );

            context.ProductStates.AddOrUpdate(p => p.Title,

                new ProductState { Title = "Active", Description = "Active", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductState { Title = "Inactive", Description = "Inactive", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductState { Title = "Expired", Description = "Expired", CreatedById = user.Id, DateCreated = DateTime.Now }
            );

            int activeProductId = context.ProductStates.Where(s => s.Title == "Active").Select(s => s.ProductStateId).FirstOrDefault();

            context.Units.AddOrUpdate(u => u.Title,
                new Unit { Title = "milliliter", BasisFactor = 1, ShortName = "ml", CreatedById = user.Id, DateCreated = DateTime.Now }
            );


            //context.Products.AddOrUpdate(p => p.Title,

            //    new Product
            //    {
            //        Title = "Guinness",
            //        Description = "Ein mild trochene Stout aus Dublin",
            //        CreatedById = user.Id,
            //        DateCreated = DateTime.Now,
            //        ExperationPeriod = 30,
            //        ProductTypeId = bierCatId,
            //        ProductStateId = activeProductId
            //    },
            //    new Product
            //    {
            //        Title = "Zipfer Märzen",
            //        Description = "In Marz gebraut, in September fertig",
            //        CreatedById = user.Id,
            //        DateCreated = DateTime.Now,
            //        ExperationPeriod = 30,
            //        ProductTypeId = bierCatId,
            //        ProductStateId = activeProductId
            //    }
            //);


            context.SaveChanges();
        }
    }
}
