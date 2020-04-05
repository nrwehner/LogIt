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
        //it's just a join table
        [Required]
        public DateTime Date { get; set; }
    }
}
