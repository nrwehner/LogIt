using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Data
{
    public class FoodDayItem: ICreateModify
    {
        [Key]
        public int FoodDayItemId { get; set; }
        [ForeignKey(nameof(FoodDay))]
        public int FoodDayId { get; set; }
        public virtual FoodDay FoodDay { get; set; }
        [ForeignKey(nameof(FoodItem))]
        public int FoodItemId { get; set; }
        public virtual FoodItem FoodItem { get; set; }
        [Required]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Required]
        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
        [Display(Name = "Modified Date")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
