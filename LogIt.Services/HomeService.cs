using LogIt.Data;
using LogIt.Models;
using LogIt.Models.Home;
using LogIt.Models.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Services
{
    public class HomeService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private readonly string _userId;
        private readonly DateTime _today;

        public HomeIndex GetModel()
        {
            return
                new HomeIndex
                {
                    Object = new HomeObject
                    {
                        UserId = _userId,
                        Today = _today,
                        Profiles = new UserProfileService(_userId).GetUserProfiles(),
                        FoodDays = new FoodDayService(_userId).GetFoodDays(),
                        FoodDayItems = new FoodDayItemService(_userId).GetAllFoodDayItemsForUser()
                   }
                };
        }

        public IEnumerable<UserProfileListItem> GetProfiles()
        {
           return new UserProfileService(_userId).GetUserProfiles();
        }
        public IEnumerable<FoodDayListItem> GetDays()
        {
            return new FoodDayService(_userId).GetFoodDays();
        }


        public HomeService(string userId,DateTime today)
        {
            _userId = userId;
            _today = today;
        }
    }
}
