using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Data
{
    public class FoodDay
    {
        [Key]
        public int FoodDayId { get; set; }
        [ForeignKey("ProfileId")]
        public string ProfileId { get; set; }
        public virtual UserProfile Profile { get; set; }
        public virtual ICollection<FoodDayItem> FoodDayItems { get; set; }
        [Required]
        public DateTime Date { get; set; }
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
