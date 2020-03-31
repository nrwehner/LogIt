using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Data
{
    public class FoodDayItem
    {
        [Key]
        public int FoodDayItemId { get; set; }
        [ForeignKey("DayId")]
        public string DayId { get; set; }
        public virtual FoodDay Day { get; set; }
        [ForeignKey("ItemId")]
        public string ItemId { get; set; }
        public virtual FoodItem Item { get; set; }
        [Required]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Required]
        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Required]
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
        [Display(Name = "Modified Date")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
