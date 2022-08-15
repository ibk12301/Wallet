using SmtWallet.Web.Data.Entities;

namespace SmtWallet.Web.Data
{
    public class SeedHelper
    {
        public static async Task InitializeData(ApplicationDbContext context)
        {
            //1. check if clients contain data
            if (!context.Clients.Any())
            {
                //2. create sample data
                context.Clients.Add(new Customer
                {
                    FirstName = "Ibukun Tunde",
                    LastName = "Ogunbunmi",
                    BirthDate = DateTime.Now.AddYears(-20),
                    Gender = GenderEnum.Male,
                    Address = "Ibadan",
                    PhoneNumber = "08101654384",
                    Email = "Pharguzin@gmail.com",
                    Active = true
                });

                context.Clients.Add(new Customer
                {
                    FirstName = "Adelakin",
                    LastName = "Segun",
                    BirthDate = DateTime.Now.AddYears(-10),
                    Gender = GenderEnum.Female,
                    Address = "Lagos",
                    PhoneNumber = "08134528765",
                    Email = "segun@gmail.com",
                    Active = false
                });

                await context.SaveChangesAsync();   
            }

            //1. check if Nationalities contain data
            if (!context.Nationalities.Any())
            {
                ////2. create sample data
                //context.Nationalities.Add(new Nationality
                //{
                //    Name = "Afghanistan",
                //    Isocode = "AFG",
                //    Callcode = "93"
                //});
                context.Nationalities.AddRange (new List<Country>
                {
                    new Country {Name = "Afghanistan", Isocode = "AFG", Callcode = "93"},
                    new Country {Name = "Albania", Isocode = "ALB", Callcode = "355"},
                    new Country {Name = "Algeria", Isocode = "DZA", Callcode = "213"}
                });
                await context.SaveChangesAsync();
            }

            if (!context.Languages.Any())
            {
                context.Languages.AddRange(new List<Language>
                {
                    new Language {Name = "English"},
                    new Language {Name = "French"},
                    new Language {Name = "German"}
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
