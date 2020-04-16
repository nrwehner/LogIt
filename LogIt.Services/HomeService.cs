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

        public HomeIndex GetModel()
        {
            IEnumerable<FoodDayListItem> foodDays = new FoodDayService(_userId).GetFoodDays();
            List<int> dayArray = new List<int>();
            List<FoodDayDetail> dayDetList = new List<FoodDayDetail>();
            foreach(FoodDayListItem day in foodDays)
            {
                if (DateTime.Now.ToShortDateString() == day.Date.ToShortDateString())
                {
                    dayArray.Add(day.FoodDayId);
                }
            }
            foreach(int i in dayArray)
            {
            dayDetList.Add(new FoodDayService(_userId).GetFoodDayById(i));
            }

            return
                new HomeIndex
                {
                    Object = new HomeObject
                    {
                        UserId = _userId,
                        Profiles = new UserProfileService(_userId).GetUserProfiles(),
                        FoodDays = foodDays,
                        FoodDayItems = new FoodDayItemService(_userId).GetAllFoodDayItemsForUser(),
                        FoodItems = new FoodItemService(_userId).GetFoodItems(),
                        TodayDetailItems = dayDetList
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

        public IEnumerable<FoodItemListItem> GetItems()
        {
            return new FoodItemService(_userId).GetFoodItems();
        }

        public FoodDayDetail GetToday(int id)
        {
            return new FoodDayService(_userId).GetFoodDayById(id);
        }

        public HomeService(string userId)
        {
            _userId = userId;
        }
    }
}
