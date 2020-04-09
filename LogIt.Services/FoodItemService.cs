using LogIt.Data;
using LogIt.Models;
using LogIt.Models.FoodItem;
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
                                NutSum = "CALs: "+e.Calories+", CARBs: "+e.CarbohydrateGrams+", FIB: "+e.FiberGrams+", FAT: "+e.FatGrams+", PROT: "+e.ProteinGrams+", SOD: "+e.SodiumMilligrams+", POT: "+e.PotassiumMilligrams,
                                CreatedBy = e.CreatedBy,
                                CreatedUtc = e.CreatedUtc
                            }
                    ); ;

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
                    IsStarred = entity.IsStarred,
                    CreatedBy = entity.CreatedBy,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedBy = entity.ModifiedBy,
                    ModifiedUtc = entity.ModifiedUtc,
                };
        }

        public bool UpdateFoodItem(FoodItemEdit model)
        {
            var entity =
                _db
                    .FoodItems
                    .Single(e => e.FoodItemId == model.FoodItemId);

            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Calories = model.Calories;
            entity.CarbohydrateGrams = model.CarbohydrateGrams;
            entity.FiberGrams = model.FiberGrams;
            entity.FatGrams = model.FatGrams;
            entity.ProteinGrams = model.ProteinGrams;
            entity.SodiumMilligrams = model.SodiumMilligrams;
            entity.PotassiumMilligrams = model.PotassiumMilligrams;
            entity.IsStarred = model.IsStarred;
            entity.ModifiedBy = _db.Users.Find(_userId).FirstName + " " + _db.Users.Find(_userId).LastName;
            entity.ModifiedUtc = DateTimeOffset.UtcNow;

            return _db.SaveChanges() == 1;
        }

        // maybe a method to allow user to duplicate a food item

        public bool DeleteFoodItem(int foodItemId)
        {
            var entity =
                _db
                    .FoodItems
                    .Single(e => e.FoodItemId == foodItemId);

            _db.FoodItems.Remove(entity);

            return _db.SaveChanges() == 1;
        }
    }
}
