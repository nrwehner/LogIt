using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Models
{
    public class FoodDayCreate
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Goal Profile Title")]
        public string ProfileTitle { get; set; }
    }
}
