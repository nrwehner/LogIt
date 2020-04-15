using LogIt.Data;
using LogIt.Models;
using LogIt.Models.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Services
{
    public class UserProfileService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private readonly string _userId;

        public UserProfileService(string userId)
        {
            _userId = userId;
        }

        public bool CreateUserProfile(UserProfileCreate model)
        {
            var entity =
                new UserProfile()
                {
                    Id = _userId,
                    Title = model.Title,
                    Description = model.Description,
                    CaloryTarget = model.CaloryTarget,
                    CarbTarget = model.CarbTarget,
                    FiberTarget = model.FiberTarget,
                    FatTarget = model.FatTarget,
                    ProteinTarget = model.ProteinTarget,
                    SodiumTarget = model.SodiumTarget,
                    PotassiumTarget = model.PotassiumTarget,
                    CreatedBy = _db.Users.Find(_userId).FirstName + " " + _db.Users.Find(_userId).LastName,
                    CreatedUtc = DateTimeOffset.Now
                };

            _db.UserProfiles.Add(entity);
            return _db.SaveChanges() == 1;
        }

        public IEnumerable<UserProfileListItem> GetUserProfiles()
        {
            var query =
                _db
                    .UserProfiles
                    .Where(e => e.Id == _userId)
                    .Select(
                        e =>
                            new UserProfileListItem
                            {
                                UserProfileId = e.UserProfileId,
                                Title = e.Title,
                                Description = e.Description,
                                Summary = "CALs: " + e.CaloryTarget + ", CARBs: " + e.CarbTarget + ", FIB: " + e.FiberTarget + ", FAT: " + e.FatTarget + ", PROT: " + e.ProteinTarget + ", SOD: " + e.SodiumTarget + ", POT: " + e.PotassiumTarget,
                                IsStarred = e.IsStarred,
                                CreatedBy = e.CreatedBy,
                                CreatedUtc = e.CreatedUtc
                            }
                    );

            return query.ToArray();
        }

        // Maybe create a GET version for the profiles pther users have made - that you can't delete or edit but you can replicate
        //- or a small library of suggested profiles that can be duplicated
        // maybe also allow a null profile - so that the user can just track baseline food data and not necessary
        // track against a goal

        public UserProfileDetail GetUserProfileById(int id)
        {
            var entity =
                _db
                    .UserProfiles
                    .Single(e => e.UserProfileId == id);
            return
                new UserProfileDetail
                {
                    UserProfileId = entity.UserProfileId,
                    FullName = _db.Users.Find(entity.Id).FirstName + " " + _db.Users.Find(entity.Id).LastName,
                    Title = entity.Title,
                    Description = entity.Description,
                    FoodDays= entity.FoodDays,
                    CaloryTarget = entity.CaloryTarget,
                    CarbTarget = entity.CarbTarget,
                    FiberTarget = entity.FiberTarget,
                    FatTarget = entity.FatTarget,
                    ProteinTarget = entity.ProteinTarget,
                    SodiumTarget = entity.SodiumTarget,
                    PotassiumTarget = entity.PotassiumTarget,
                    IsStarred = entity.IsStarred,
                    CreatedBy = entity.CreatedBy,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedBy = entity.ModifiedBy,
                    ModifiedUtc = entity.ModifiedUtc,
                };
        }

        public bool UpdateUserProfile(UserProfileEdit model)
        {
            var entity =
                _db
                    .UserProfiles
                    .Single(e => e.UserProfileId == model.UserProfileId);

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.CaloryTarget = model.CaloryTarget;
            entity.CarbTarget = model.CarbTarget;
            entity.FiberTarget = model.FiberTarget;
            entity.FatTarget = model.FatTarget;
            entity.ProteinTarget = model.ProteinTarget;
            entity.SodiumTarget = model.SodiumTarget;
            entity.PotassiumTarget = model.PotassiumTarget;
            entity.IsStarred = model.IsStarred;
            entity.ModifiedBy = _db.Users.Find(_userId).FirstName + " " + _db.Users.Find(_userId).LastName;
            entity.ModifiedUtc = DateTimeOffset.UtcNow;

            return _db.SaveChanges() == 1;
        }

        // maybe a method to allow user to duplicate a UserProfile


        //need to think about how to handle this regarding how it will affect the fooddays
        //- either don't allow it, or prompt the user excessively that you will also be deleting foodday data? maybe even display all
        // the foodday data or a summary - count of days, data range, etc. - also test and see what actually happens when you do this
        // - do all children get delete or just become orphans?
        public bool DeleteUserProfile(int userProfileId)
        {
            var entity =
                _db
                    .UserProfiles
                    .Single(e => e.UserProfileId == userProfileId);

            _db.UserProfiles.Remove(entity);

            return _db.SaveChanges() == 1;
        }
    }
}
