using Microsoft.EntityFrameworkCore;

namespace apiforapp.Models
{
    public class apDbcontext : DbContext
    {
        public apDbcontext(DbContextOptions<apDbcontext> options)
        : base(options)
        {
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<FoodPart> foodParts { get; set;   }
        public DbSet<Statebody> Statebody { get; set; }
        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<Food> foods { get; set; }
        public DbSet<Nutribution> nutributions { get; set; }
        public DbSet<DetailNutributionFood> detailNutributionFoods { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<DetailPurpose> detailPurposes { get; set; }
        public DbSet<Diet> diets { get; set; }
        public DbSet<DetailDietFood> detailDietFoods { get; set; }
        public DbSet<Rate> rates { get; set; }
    }
}
