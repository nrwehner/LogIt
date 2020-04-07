using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Models
{
    public class FoodDayItemCreate
    {
        [Required]
        public int FoodDayId { get; set; }
        [Required]
        [Display(Name = "Food Item Name")]
        public string FoodItemName { get; set; }
    }
}
