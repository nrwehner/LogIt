using LogIt.Data;
using LogIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Services
{
    public class FoodItemService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private readonly string _userId;

        public FoodItemService(string userId)
        {
            _userId = userId;
        }

        public bool CreateFoodItem(FoodItemCreate model)
        {
            var entity =
                new FoodItem()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Calories = model.Calories,
                    CarbohydrateGrams = model.CarbohydrateGrams,
                    FatGrams = model.FatGrams,
                    FiberGrams = model.FiberGrams,
                    ProteinGrams = model.ProteinGrams,
                    SodiumMilligrams = model.SodiumMilligrams,
                    PotassiumMilligrams = model.PotassiumMilligrams,
                    CreatedBy = _db.Users.Find(_userId).FirstName + " " + _db.Users.Find(_userId).LastName,
                    CreatedUtc = DateTimeOffset.Now
                };

            _db.FoodItems.Add(entity);
            return _db.SaveChanges() == 1;
        }

        public IEnumerable<FoodItemListItem> GetFoodItems()
        {
            var query =
                _db
                    .FoodItems
                    .Select(
                        e =>
                            new FoodItemListItem
                            {
                                FoodItemId = e.FoodItemId,
                                Name = e.Name,
                                Description = e.Description,
                                CreatedBy = e.CreatedBy,
                                CreatedUtc = e.CreatedUtc
                            }
                    );

            return query.ToArray();
        }

        // Maybe create a GET version for the food items the user has made

        public FoodItemDetail GetFoodItemById(int id)
        {
            var entity =
                _db
                    .FoodItems
                    .Single(e => e.FoodItemId == id);
            return
                new FoodItemDetail
                {
                    FoodItemId = entity.FoodItemId,
                    Name = entity.Name,
                    Description = entity.Description,
                    Calories = entity.Calories,
                    CarbohydrateGrams = entity.CarbohydrateGrams,
                    FiberGrams = entity.FiberGrams,
                    FatGrams = entity.FatGrams,
                    ProteinGrams = entity.ProteinGrams,
                    SodiumMilligrams = entity.SodiumMilligrams,
                    PotassiumMilligrams = entity.PotassiumMilligrams,
                    CreatedBy = entity.CreatedBy,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedBy = entity.ModifiedBy,
                    ModifiedUtc = entity.ModifiedUtc,
                };
        }
    }
}
