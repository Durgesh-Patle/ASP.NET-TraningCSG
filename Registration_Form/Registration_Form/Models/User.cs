using System.ComponentModel.DataAnnotations;

namespace Registration_Form.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string StreetAddress { get; set; }

        public string StateName { get; set; }

        public string CountryName { get; set; }

        public string AreaCode { get; set; }
    }
}
