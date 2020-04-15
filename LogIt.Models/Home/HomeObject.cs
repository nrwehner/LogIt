using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogIt.Data;
using LogIt.Models.UserProfile;

namespace LogIt.Models.Home
{
    public class HomeObject
    {
        public string UserId { get; set; }
        public DateTime Today { get; set; }
        public IEnumerable<UserProfileListItem> Profiles { get; set; }
        public IEnumerable<FoodDayListItem> FoodDays { get; set; }
        public IEnumerable<FoodDayItemListItem> FoodDayItems { get; set; }

    }
}
