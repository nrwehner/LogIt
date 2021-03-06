﻿using System;
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
        [Display(Name = "Food Day Id")]
        public int FoodDayId { get; set; }
        [Display(Name = "Food Item Id")]
        public int FoodItemId { get; set; }
    }
}
