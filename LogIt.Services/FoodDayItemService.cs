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
    public class FoodDayItemService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private readonly string _userId;

        public FoodDayItemService(string userId)
        {
            _userId = userId;
        }

        public bool CreateFoodDayItem(FoodDayItemCreate model)
        {
            var entity =
                new FoodDayItem()
                {
                    FoodDayId = model.FoodDayId,
                    FoodItemId = _db.FoodItems.FirstOrDefault(e => e.Name == model.FoodItemName).FoodItemId,//this needs to be looked into - if food item name gets used twice, this could cause issues with selecting the right one - dropdown solves it?
                    CreatedBy = _db.Users.Find(_userId).FirstName + " " + _db.Users.Find(_userId).LastName,
                    CreatedUtc = DateTimeOffset.Now
                };

            _db.FoodDayItems.Add(entity);
            return _db.SaveChanges() == 1;
        }
        public IEnumerable<FoodDayItemListItem> GetAllFoodDayItemsForUser()
        {
            var query =
                _db
                    .FoodDayItems
                    .Where(e => e.FoodDay.UserProfile.Id == _userId)
                    .Select(
                        e =>
                            new FoodDayItemListItem
                            {
                                FoodDayItemId = e.FoodDayItemId,
                                FoodDayId = e.FoodDayId,
                                Date = e.FoodDay.Date,
                                ProfileTitle = e.FoodDay.UserProfile.Title,
                                FoodItemId = e.FoodItemId,
                                FoodItemName = e.FoodItem.Name,
                                CreatedBy = e.CreatedBy,
                                CreatedUtc = e.CreatedUtc
                            }
                    );

            return query.ToArray();
        }

        public IEnumerable<FoodDayItemListItem> GetFoodDayItemsByFoodDay(int foodDayId)
        {
            var query =
                _db
                    .FoodDayItems
                    .Where(e => e.FoodDayId == foodDayId)
                    .Select(
                        e =>
                            new FoodDayItemListItem
                            {
                                FoodDayItemId = e.FoodDayItemId,
                                FoodDayId = e.FoodDayId,
                                Date = e.FoodDay.Date,
                                ProfileTitle = e.FoodDay.UserProfile.Title,
                                FoodItemId=e.FoodItemId,
                                FoodItemName=e.FoodItem.Name,
                                CreatedBy = e.CreatedBy,
                                CreatedUtc = e.CreatedUtc
                            }
                    );

            return query.ToArray();
        }

        public FoodDayItemDetail GetFoodDayItemById(int id)
        {
            var entity =
                _db
                    .FoodDayItems
                    .Single(e => e.FoodDayItemId == id);
            return
                new FoodDayItemDetail
                {
                    FoodDayItemId = entity.FoodDayItemId,
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

        /*public bool UpdateFoodDayItem(FoodDayItemEdit model)
        {
            var entity =
                _db
                    .FoodDayItems
                    .Single(e => e.FoodDayItemId == model.FoodDayItemId);

            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Calories = model.Calories;
            entity.CarbohydrateGrams = model.CarbohydrateGrams;
            entity.FiberGrams = model.FiberGrams;
            entity.FatGrams = model.FatGrams;
            entity.ProteinGrams = model.ProteinGrams;
            entity.SodiumMilligrams = model.SodiumMilligrams;
            entity.PotassiumMilligrams = model.PotassiumMilligrams;
            entity.ModifiedBy = _db.Users.Find(_userId).FirstName + " " + _db.Users.Find(_userId).LastName;
            entity.ModifiedUtc = DateTimeOffset.UtcNow;

            return _db.SaveChanges() == 1;
        }

        public bool DeleteFoodDayItem(int foodDayItemId)
        {
            var entity =
                _db
                    .FoodDayItems
                    .Single(e => e.FoodDayItemId == foodDayItemId);

            _db.FoodDayItems.Remove(entity);

            return _db.SaveChanges() == 1;
        }*/
    }
}
