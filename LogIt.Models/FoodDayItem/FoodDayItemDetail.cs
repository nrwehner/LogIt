using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Models
{
    public class FoodDayItemDetail
    {
        //it's just a join table
        [Display(Name = "Food Day Item Id")]
        public int FoodDayItemId { get; set; }
        [Display(Name = "Food Day Id")]
        public int FoodDayId { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Goal Profile Title")]
        public string ProfileTitle { get; set; }
        [Display(Name = "Goal Profile Description")]
        public string ProfileDescription { get; set; }
        [Display(Name = "Food Item Id")]
        public int FoodItemId { get; set; }
        [Display(Name = "Food Item Name")]
        public string FoodItemName { get; set; }
        [Display(Name = "Food Item Calories")]
        public int ItemCalories { get; set; }
        [Display(Name = "Daily Total Calorie Target")]
        public int CalorieTarget { get; set; }
        [Display(Name = "Calorie Proportion")]
        public double CalorieWeight { get; set; }
        [Display(Name = "Food Item Carbs")]
        public double ItemCarbs { get; set; }
        [Display(Name = "Daily Total Carb Target")]
        public double CarbTarget { get; set; }
        [Display(Name = "Carb Weight")]
        public double CarbWeight { get; set; }
        [Display(Name = "Food Item Fiber")]
        public double ItemFiber { get; set; }
        [Display(Name = "Daily Total Fiber Target")]
        public double FiberTarget { get; set; }
        [Display(Name = "Fiber Weight")]
        public double FiberWeight { get; set; }
        [Display(Name = "Food Item Fat")]
        public double ItemFat { get; set; }
        [Display(Name = "Daily Total Fat Target")]
        public double FatTarget { get; set; }
        [Display(Name = "Fat Weight")]
        public double FatWeight { get; set; }
        [Display(Name = "Food Item Protein")]
        public double ItemProtein { get; set; }
        [Display(Name = "Daily Total Protein Target")]
        public double ProteinTarget { get; set; }
        [Display(Name = "Protein Weight")]
        public double ProteinWeight { get; set; }
        [Display(Name = "Food Item Sodium")]
        public int ItemSodium { get; set; }
        [Display(Name = "Daily Total Sodium Target")]
        public int SodiumTarget { get; set; }
        [Display(Name = "Sodium Weight")]
        public double SodiumWeight { get; set; }
        [Display(Name = "Food Item Potassium")]
        public int ItemPotassium { get; set; }
        [Display(Name = "Daily Total Potassium Target")]
        public int PotassiumTarget { get; set; }
        [Display(Name = "Potassium Weight")]
        public double PotassiumWeight { get; set; }
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
