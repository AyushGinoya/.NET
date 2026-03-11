using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewDemo.Models
{
    public class Student
    {
        public Int32 Id { get; set; }

        [DisplayName("Full Name")]
        [Required(ErrorMessage = "Name is required")]
        public String Name { get; set; }

        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(9, 100, ErrorMessage = "Age must be between 9 and 100")]
        public Int32 Age { get; set; }

        public String Gender { get; set; }

        [Required(ErrorMessage = "Please select a course")]
        public String Course { get; set; }

        public Boolean IsActive { get; set; }

    }
}
