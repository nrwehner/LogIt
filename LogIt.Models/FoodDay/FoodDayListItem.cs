using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Models
{
    public class FoodDayListItem
    {
        [Display(Name = "Food Day Id")]
        public int FoodDayId { get; set; }
        [Display(Name = "Date - Profile")]
        public string DateProfile { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Goal Profile Title")]
        public string Title { get; set; }
        [Display(Name = "Goal Profile Description")]
        public string Description { get; set; }
        [Display(Name = "Food Day Details")]
        public FoodDayDetail FoodDayDetails { get; set; }
        public string Summary { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
