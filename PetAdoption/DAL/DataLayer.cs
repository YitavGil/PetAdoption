using Microsoft.EntityFrameworkCore;
using PetAdoption.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace PetAdoption.DAL
{
    public class DataLayer : DbContext
    {
        //בוב הבנאי 
        public DataLayer(string ConnectionString) : base(GetOptions(ConnectionString)) {
            // יוצר את הדאטאבייס אם הוא לא קיים
            Database.EnsureCreated();

            //פונקציה שמכניסה לדאטאבייס
            if (Pets.Count() == 0) Seed();

     }

        public void Seed()
        {
            //מכניס נתונים משלי לבדיקה 
            Pet pet = new Pet
            {
                Name = "קפטן",
                PetType = "כלב",
                Age = 3,
                PhoneNumber = "1234",
                Email = "hello@hello.com",

            };
            Pets.Add(pet);
            SaveChanges();
        }

        // פונקציה פרטית ליצירת אפשרויות חיבור לדאטאבייס

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(),
                connectionString).Options;
        }


        // הגדרת הטבלאות בדאטאבייס

        public DbSet<Pet> Pets { get; set; } 
        public DbSet<Image> Images { get; set; }
    }
}
