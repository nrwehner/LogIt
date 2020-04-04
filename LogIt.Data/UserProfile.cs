using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Data
{
    public class UserProfile
    {
        [Key]
        public int UserProfileId { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<FoodDay> FoodDays { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "The Title cannot exceed 30 characters.")]
        public string Title { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "The Description cannot exceed 300 characters.")]
        public string Description { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "please choose a whole number between 0 and 10,000")]
        [Display(Name = "Calory Target")]
        public int CaloryTarget { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "please choose a number between 0 and 1,000")]
        [Display(Name = "Carbohydrate Target")]
        public double CarbTarget { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "please choose a number between 0 and 1,000")]
        [Display(Name = "Fiber Target")]
        public double FiberTarget { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "please choose a number between 0 and 1,000")]
        [Display(Name = "Fat Target")]
        public double FatTarget { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "please choose a number between 0 and 1,000")]
        [Display(Name = "Protein Target")]
        public double ProteinTarget { get; set; }
        [Required]
        [Range(0, 15000, ErrorMessage = "please choose a whole number between 0 and 15,000")]
        [Display(Name = "Sodium Target")]
        public int SodiumTarget { get; set; }
        [Required]
        [Range(0, 15000, ErrorMessage = "please choose a whole number between 0 and 15,000")]
        [Display(Name = "Potassium Target")]
        public int PotassiumTarget { get; set; }
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
