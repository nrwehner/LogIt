using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Models
{
    public class FoodDayDetail
    {
        [Display(Name = "Food Day Id")]
        public int FoodDayId { get; set; }
        //public virtual ICollection<FoodDayItem> FoodDayItems { get; set; } //maybe use this at some point to create a 
        //field that can count how many food items are in the day or even potentially pull summary data (calories, carbs, etc) for the day?
        public DateTime Date { get; set; }
        [Display(Name = "Goal Profile Title")]
        public string ProfileTitle { get; set; }
        [Display(Name = "Goal Profile Description")]
        public string ProfileDescription { get; set; }
        [Display(Name = "Goal Profile Calories")]
        public int ProfileCalories { get; set; }
        [Display(Name = "Actual Daily Calories")]
        public int CaloriesSum { get; set; }
        [Display(Name = "Calories Diff")]
        public int CaloriesDiff { get; set; }
        [Display(Name = "Goal Profile Carbs (Net)")]
        public double ProfileCarbs { get; set; }
        [Display(Name = "Actual Daily Carbs (Net)")]
        public int CarbsSum { get; set; }
        [Display(Name = "Carbs (Net) Diff")]
        public int CarbsDiff { get; set; }
        [Display(Name = "Goal Profile Fiber")]
        public double ProfileFiber { get; set; }
        [Display(Name = "Actual Daily Fiber")]
        public int FiberSum { get; set; }
        [Display(Name = "Fiber Diff")]
        public int FiberDiff { get; set; }
        [Display(Name = "Goal Profile Fat")]
        public double ProfileFat { get; set; }
        [Display(Name = "Actual Daily Fat")]
        public int FatSum { get; set; }
        [Display(Name = "Fat Diff")]
        public int FatDiff { get; set; }
        [Display(Name = "Goal Profile Protein")]
        public double ProfileProtein { get; set; }
        [Display(Name = "Actual Daily Protein")]
        public int ProteinSum { get; set; }
        [Display(Name = "Protein Diff")]
        public int ProteinDiff { get; set; }
        [Display(Name = "Goal Profile Sodium")]
        public int ProfileSodium { get; set; }
        [Display(Name = "Actual Daily Sodium")]
        public int SodiumSum { get; set; }
        [Display(Name = "Sodium Diff")]
        public int SodiumDiff { get; set; }
        [Display(Name = "Goal Profile Potassium")]
        public int ProfilePotassium { get; set; }
        [Display(Name = "Actual Daily Potassium")]
        public int PotassiumSum { get; set; }
        [Display(Name = "Potassium Diff")]
        public int PotassiumDiff { get; set; }
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
