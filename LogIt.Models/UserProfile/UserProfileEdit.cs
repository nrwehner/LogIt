using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Models.UserProfile
{
    public class UserProfileEdit
    {
        [Display(Name = "Profile Id")]
        public int UserProfileId { get; set; }
        [Display(Name = "Profile Title")]
        public string Title { get; set; }
        [Display(Name = "Profile Description")]
        public string Description { get; set; }
        [Display(Name = "Calory Target")]
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
        public bool IsStarred { get; set; }
    }
}
