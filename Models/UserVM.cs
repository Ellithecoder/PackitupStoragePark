using System.ComponentModel.DataAnnotations;

namespace PackitupStoragePark.Models
{
    public class UserVM
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}
