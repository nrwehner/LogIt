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
                    FoodItemId = model.FoodItemId,
                    CreatedBy = _db.Users.Find(_userId).FirstName + " " + _db.Users.Find(_userId).LastName,
                    CreatedUtc = DateTimeOffset.Now
                };

            _db.FoodDayItems.Add(entity);
            return _db.SaveChanges() == 1;
        }
        public IEnumerable<FoodDayItemListItem> GetFoodDayItems(IEnumerable<FoodDayItem> list)
        {
            var query =
                    list
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
            double calWeight = ((double)entity.FoodItem.Calories / (double)entity.FoodDay.UserProfile.CaloryTarget);
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
                    CalorieTarget = entity.FoodDay.UserProfile.CaloryTarget,
                    CalorieWeight = calWeight,
                    ItemCarbs = entity.FoodItem.CarbohydrateGrams,
                    CarbTarget = entity.FoodDay.UserProfile.CaloryTarget,
                    CarbWeight = (entity.FoodItem.CarbohydrateGrams/entity.FoodDay.UserProfile.CarbTarget)/ calWeight,
                    ItemFiber = entity.FoodItem.FiberGrams,
                    FiberTarget = entity.FoodDay.UserProfile.FiberTarget,
                    FiberWeight = (entity.FoodItem.FiberGrams / entity.FoodDay.UserProfile.FiberTarget) / calWeight,
                    ItemFat=entity.FoodItem.FatGrams,
                    FatTarget = entity.FoodDay.UserProfile.FatTarget,
                    FatWeight = (entity.FoodItem.FatGrams / entity.FoodDay.UserProfile.FatTarget) / calWeight,
                    ItemProtein = entity.FoodItem.ProteinGrams,
                    ProteinTarget = entity.FoodDay.UserProfile.ProteinTarget,
                    ProteinWeight = (entity.FoodItem.ProteinGrams / entity.FoodDay.UserProfile.ProteinTarget) / calWeight,
                    ItemSodium = entity.FoodItem.SodiumMilligrams,
                    SodiumTarget = entity.FoodDay.UserProfile.SodiumTarget,
                    SodiumWeight = ((double)entity.FoodItem.SodiumMilligrams / entity.FoodDay.UserProfile.SodiumTarget) / calWeight,
                    ItemPotassium = entity.FoodItem.PotassiumMilligrams,
                    PotassiumTarget = entity.FoodDay.UserProfile.PotassiumTarget,
                    PotassiumWeight = ((double)entity.FoodItem.PotassiumMilligrams / entity.FoodDay.UserProfile.PotassiumTarget) / calWeight,
                    CreatedBy = entity.CreatedBy,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedBy = entity.ModifiedBy,
                    ModifiedUtc = entity.ModifiedUtc,
                };
        }

        public bool UpdateFoodDayItem(FoodDayItemEdit model)
        {
            var entity =
                _db
                    .FoodDayItems
                    .Single(e => e.FoodDayItemId == model.FoodDayItemId);

            entity.FoodItemId = model.FoodItemId;
            entity.FoodDayId = model.FoodDayId;
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
