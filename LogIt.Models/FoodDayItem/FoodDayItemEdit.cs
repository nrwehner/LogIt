﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Models.FoodItem
{
    public class FoodDayItemEdit
    {
        //it's just a join table
        [Display(Name = "Day Id")]
        public int FoodDayId { get; set; }
        public DateTime Date { get; set; }
    }
}