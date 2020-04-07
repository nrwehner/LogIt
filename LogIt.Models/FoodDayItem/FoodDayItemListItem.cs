using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Models
{
    public class FoodDayItemListItem
    {
        [Display(Name = "Food Day Item Id")]
        public int FoodDayItemId { get; set; }
        [Display(Name = "Food Day Id")]
        public int FoodDayId { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Goal Profile Title")]
        public string ProfileTitle { get; set; }
        [Display(Name = "Food Item Id")]
        public int FoodItemId { get; set; }
        [Display(Name = "Food Item Name")]
        public string FoodItemName { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
