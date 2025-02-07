using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute= System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace FirstWebApp.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(20000, 1000000, ErrorMessage = "Salary must be between 10,000 and 200,000")]
        public decimal Salary { get; set; }
    }
}
