using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Models.UserProfile
{
    public class UserProfileListItem
    {
        [Display(Name = "Item Id")]
        public int UserProfileId { get; set; }
        [Display(Name = "Profile Title")]
        public string Title { get; set; }
        [Display(Name = "Profile Description")]
        public string Description { get; set; }
        [UIHint("Starred")]
        public bool IsStarred { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
