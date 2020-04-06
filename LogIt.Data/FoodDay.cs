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
        [ForeignKey(nameof(UserProfile))]
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<FoodDayItem> FoodDayItems { get; set; }
        [Required]
        public DateTime Date { get; set; }
        //maybe add a notes property or think of other things that could make the day table more justifiable - otherwise Date is really
        // the only distinguishing feature of this table and that could potentially just be a property of UserProfile - the downside of
        // that is that UserProfile then has many more children - every food item on every day is a child of Profile - but in this case - 
        // the children of FoodDay is limited to only the amount of food items you could use in a day
        // actually - nevermind, profile records shouldn't really be re-saved for each date, that's unecessary redundancy of the profile data
        // just thinking out loud...
        // but you could join profile and food item and have a date property in the join table rather than joining foodday and fooditem
        // in this case you would pull a "day" by querying the join table for all records with the same value in the Date property
        // just another way to do it and have one less table - but if i want to be able to have additional properties associated with the day
        // like a "notes for the day" or something, then foodday has to be a separate table, otherwise the "note" would go on a fooddayitem, not the whole day
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
