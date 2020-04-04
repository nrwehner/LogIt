using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Models.FoodItem
{
    public class FoodItemEdit
    {
        [Display(Name = "Item Id")]
        public int FoodItemId { get; set; }
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
    }
}
