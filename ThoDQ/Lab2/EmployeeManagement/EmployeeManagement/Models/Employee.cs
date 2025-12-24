using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [Range(18, 65)]
        public int Age { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }

}
