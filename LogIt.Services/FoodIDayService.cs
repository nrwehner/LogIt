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
                    UserProfileId = _db.UserProfiles.Find(model.ProfileTitle).UserProfileId,
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
                    .Where
                    .Select(
                        e =>
                            new FoodDayListItem
                            {
                                FoodDayId = e.FoodDayId,
                                Name = e.Name,
                                Description = e.Description,
                                IsStarred = e.IsStarred,
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
            return
                new FoodDayDetail
                {
                    FoodDayId = entity.FoodDayId,
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

        public bool UpdateFoodDay(FoodDayEdit model)
        {
            var entity =
                _db
                    .FoodDays
                    .Single(e => e.FoodDayId == model.FoodDayId);

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
