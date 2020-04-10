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
        [Display(Name = "Goal Profile Id")]
        public int UserProfileId { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
