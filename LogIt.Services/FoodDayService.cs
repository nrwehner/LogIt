using LogIt.Data;
using LogIt.Models;
using LogIt.Models.FoodDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Services
{
    public class FoodDayService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private readonly string _userId;

        public FoodDayService(string userId)
        {
            _userId = userId;
        }

        public bool CreateFoodDay(FoodDayCreate model)
        {
            var entity =
                new FoodDay()
                {
                    UserProfileId = _db.UserProfiles.FirstOrDefault(e => e.Title==model.ProfileTitle).UserProfileId,//this needs to be looked into - if profile title gets used twice, this could cause issues
                    Date = model.Date,
                    CreatedBy = _db.Users.Find(_userId).FirstName + " " + _db.Users.Find(_userId).LastName,
                    CreatedUtc = DateTimeOffset.Now
                };

            _db.FoodDays.Add(entity);
            return _db.SaveChanges() == 1;
        }

        public bool CreateFoodDayFromProfile(FoodDayCreateFromProfile model)
        {
            var entity =
                new FoodDay()
                {
                    UserProfileId = model.UserProfileId,
                    Date = model.Date,
                    CreatedBy = _db.Users.Find(_userId).FirstName + " " + _db.Users.Find(_userId).LastName,
                    CreatedUtc = DateTimeOffset.Now
                };

            _db.FoodDays.Add(entity);
            return _db.SaveChanges() == 1;
        }


        public IEnumerable<FoodDayListItem> GetFoodDays()
        {
            var query =
                _db
                    .FoodDays
                    .Where(e => e.UserProfile.ApplicationUser.Id == _userId)//need to re-look at this - you can created a foodday of a profile that is not yours right now - but it won't display in your fooddays - probably once I build a drop-down constraint, you won't be able to use profiles that aren't yours
                    .Select(
                        e =>
                            new FoodDayListItem
                            {
                                FoodDayId = e.FoodDayId,
                                Date = e.Date,
                                Title = e.UserProfile.Title,
                                Description = e.UserProfile.Description,
                                CreatedBy = e.CreatedBy,
                                CreatedUtc = e.CreatedUtc
                            }
                    );

            return query.ToArray();
        }

        public FoodDayDetail GetFoodDayById(int id)

        {
            var entity =
                _db
                    .FoodDays
                    .Single(e => e.FoodDayId == id);
            int calSum = 0;
            double carbSum = 0;
            double fiberSum = 0;
            double fatSum = 0;
            double proteinSum = 0;
            int sodSum = 0;
            int potSum = 0;
            foreach (FoodDayItem item in entity.FoodDayItems)
            {
                calSum += item.FoodItem.Calories;
                carbSum += item.FoodItem.CarbohydrateGrams;
                fiberSum += item.FoodItem.FiberGrams;
                fatSum += item.FoodItem.FatGrams;
                proteinSum += item.FoodItem.ProteinGrams;
                sodSum += item.FoodItem.SodiumMilligrams;
                potSum += item.FoodItem.PotassiumMilligrams;
            }
            return
                new FoodDayDetail
                {
                    FoodDayId = entity.FoodDayId,
                    Date = entity.Date,
                    ProfileTitle = entity.UserProfile.Title,
                    ProfileDescription = entity.UserProfile.Description,
                    ProfileCalories = entity.UserProfile.CaloryTarget,
                    CaloriesSum = calSum,
                    CaloriesDiff = calSum- entity.UserProfile.CaloryTarget,
                    ProfileCarbs = entity.UserProfile.CarbTarget,
                    CarbsSum = carbSum,
                    CarbsDiff = carbSum - entity.UserProfile.CarbTarget,
                    ProfileFiber = entity.UserProfile.FiberTarget,
                    FiberSum = fiberSum,
                    FiberDiff = fiberSum - entity.UserProfile.FiberTarget,
                    ProfileFat = entity.UserProfile.FatTarget,
                    FatSum = fatSum,
                    FatDiff = fatSum - entity.UserProfile.FatTarget,
                    ProfileProtein = entity.UserProfile.ProteinTarget,
                    ProteinSum = proteinSum,
                    ProteinDiff = proteinSum - entity.UserProfile.ProteinTarget,
                    ProfileSodium = entity.UserProfile.SodiumTarget,
                    SodiumSum = sodSum,
                    SodiumDiff = sodSum - entity.UserProfile.SodiumTarget,
                    ProfilePotassium = entity.UserProfile.PotassiumTarget,
                    PotassiumSum = potSum,
                    PotassiumDiff = potSum - entity.UserProfile.PotassiumTarget,
                    CreatedBy = entity.CreatedBy,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedBy = entity.ModifiedBy,
                    ModifiedUtc = entity.ModifiedUtc,
                };
        }

        public bool UpdateFoodDay(FoodDayEdit model)
        {
            var entity =
                _db
                    .FoodDays
                    .Single(e => e.FoodDayId == model.FoodDayId);

            entity.Date = model.Date;
            entity.UserProfileId = _db.UserProfiles.FirstOrDefault(e => e.Title == model.ProfileTitle).UserProfileId;
            entity.ModifiedBy = _db.Users.Find(_userId).FirstName + " " + _db.Users.Find(_userId).LastName;
            entity.ModifiedUtc = DateTimeOffset.UtcNow;

            return _db.SaveChanges() == 1;
        }

        public bool DeleteFoodDay(int foodDayId)
        {
            var entity =
                _db
                    .FoodDays
                    .Single(e => e.FoodDayId == foodDayId);

            _db.FoodDays.Remove(entity);

            return _db.SaveChanges() == 1;
        }
    }
}
