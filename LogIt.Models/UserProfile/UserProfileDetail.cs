using LogIt.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogIt.Models.UserProfile
{
    public class UserProfileDetail
    {
        [Display(Name = "Profile Id")]
        public int UserProfileId { get; set; }
        [Display(Name = "User")]
        public string FullName { get; set; }
        public IEnumerable<LogIt.Data.FoodDay> FoodDays { get; set; }
        [Display(Name = "Profile Title")]
        public string Title { get; set; }
        [Display(Name = "Profile Description")]
        public string Description { get; set; }
        [Display(Name = "Calorie Target")]
        public int CaloryTarget { get; set; }
        [Display(Name = "Carbohydrate Target (Net)")]
        public double CarbTarget { get; set; }
        [Display(Name = "Fiber Target")]
        public double FiberTarget { get; set; }
        [Display(Name = "Fat Target")]
        public double FatTarget { get; set; }
        [Display(Name = "Protein Target")]
        public double ProteinTarget { get; set; }
        [Display(Name = "Sodium Target")]
        public int SodiumTarget { get; set; }
        [Display(Name = "Potassium Target")]
        public int PotassiumTarget { get; set; }
        [UIHint("Starred")]
        public bool IsStarred { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
        [Display(Name = "Modified Date")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
