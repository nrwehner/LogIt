using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Models
{
    public class FoodItemDetail
    {
        [Display(Name = "Item Id")]
        public int FoodItemId { get; set; }
        //public virtual ICollection<FoodDayItem> FoodDayItems { get; set; } //maybe use this at some point to create a field that can count how many times the food item has been used?
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        [Display(Name = "Item Description")]
        public string Description { get; set; }
        public int Calories { get; set; }
        [Display(Name = "Grams Of Carbohydrate (Net)")]
        public double CarbohydrateGrams { get; set; }
        [Display(Name = "Grams Of Fiber")]
        public double FiberGrams { get; set; }
        [Display(Name = "Grams Of Fat")]
        public double FatGrams { get; set; }
        [Display(Name = "Grams Of Protein")]
        public double ProteinGrams { get; set; }
        [Display(Name = "Mgs Of Sodium")]
        public int SodiumMilligrams { get; set; }
        [Display(Name = "Mgs Of Potassium")]
        public int PotassiumMilligrams { get; set; }
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
