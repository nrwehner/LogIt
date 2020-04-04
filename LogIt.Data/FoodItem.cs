using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Data
{
    public class FoodItem
    {
        [Key]
        public int FoodItemId { get; set; }
        public virtual ICollection<FoodDayItem> FoodDayItems { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The Name cannot exceed 50 characters.")]
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "The Description cannot exceed 300 characters.")]
        [Display(Name = "Item Description")]
        public string Description { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "please choose a whole number between 0 and 10,000")]
        public int Calories { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "please choose a number between 0 and 1,000")]
        [Display(Name = "Grams Of Carbohydrate")]
        public double CarbohydrateGrams { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "please choose a number between 0 and 1,000")]
        [Display(Name = "Grams Of Fiber")]
        public double FiberGrams { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "please choose a number between 0 and 1,000")]
        [Display(Name = "Grams Of Fat")]
        public double FatGrams { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "please choose a number between 0 and 1,000")]
        [Display(Name = "Grams Of Protein")]
        public double ProteinGrams { get; set; }
        [Required]
        [Range(0, 15000, ErrorMessage = "please choose a whole number between 0 and 15,000")]
        [Display(Name = "Mgs Of Sodium")]
        public int SodiumMilligrams { get; set; }
        [Required]
        [Range(0, 15000, ErrorMessage = "please choose a whole number between 0 and 15,000")]
        [Display(Name = "Mgs Of Potassium")]
        public int PotassiumMilligrams { get; set; }
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
