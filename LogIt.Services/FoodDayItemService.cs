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
                    FoodDayId = entity.FoodDayId,
                    Date = entity.FoodDay.Date,
                    ProfileTitle = entity.FoodDay.UserProfile.Title,
                    ProfileDescription = entity.FoodDay.UserProfile.Description,
                    FoodItemId = entity.FoodItemId,
                    FoodItemName = entity.FoodItem.Name,
                    ItemCalories = entity.FoodItem.Calories,
                    CalorieWeight = (entity.FoodItem.Calories/entity.FoodDay.UserProfile.CaloryTarget),
                    ItemCarbs = entity.FoodItem.CarbohydrateGrams,
                    CarbWeight = (entity.FoodItem.CarbohydrateGrams/entity.FoodDay.UserProfile.CarbTarget)/(entity.FoodItem.Calories/entity.FoodDay.UserProfile.CaloryTarget),
                    ItemFiber = entity.FoodItem.FiberGrams,
                    FiberWeight = (entity.FoodItem.CarbohydrateGrams / entity.FoodDay.UserProfile.CarbTarget) / (entity.FoodItem.Calories / entity.FoodDay.UserProfile.CaloryTarget),
                    ItemFat=entity.FoodItem.FatGrams,
                    FatWeight = (entity.FoodItem.CarbohydrateGrams / entity.FoodDay.UserProfile.CarbTarget) / (entity.FoodItem.Calories / entity.FoodDay.UserProfile.CaloryTarget),
                    ItemProtein = entity.FoodItem.ProteinGrams,
                    ProteinWeight = (entity.FoodItem.CarbohydrateGrams / entity.FoodDay.UserProfile.CarbTarget) / (entity.FoodItem.Calories / entity.FoodDay.UserProfile.CaloryTarget),
                    ItemSodium = entity.FoodItem.SodiumMilligrams,
                    SodiumWeight = (entity.FoodItem.CarbohydrateGrams / entity.FoodDay.UserProfile.CarbTarget) / (entity.FoodItem.Calories / entity.FoodDay.UserProfile.CaloryTarget),
                    ItemPotassium = entity.FoodItem.PotassiumMilligrams,
                    PotassiumWeight = (entity.FoodItem.CarbohydrateGrams / entity.FoodDay.UserProfile.CarbTarget) / (entity.FoodItem.Calories / entity.FoodDay.UserProfile.CaloryTarget),
                    CreatedBy = entity.CreatedBy,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedBy = entity.ModifiedBy,
                    ModifiedUtc = entity.ModifiedUtc,
                };
        }

        public bool UpdateFoodDayItem(FoodDayItemEdit model)//this is only allowing the user to change the food item - 
            //if you want to be able to change the foodday also, do separate method - i'm not sure if you would ever want to do that, 
            //though - you will always be adding, editng, and deleting foodayitems within a specific foodday
        {
            var entity =
                _db
                    .FoodDayItems
                    .Single(e => e.FoodDayItemId == model.FoodDayItemId);

            entity.FoodItemId = _db.FoodItems.FirstOrDefault(e => e.Name == model.FoodItemName).FoodItemId;
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
        }
    }
}
