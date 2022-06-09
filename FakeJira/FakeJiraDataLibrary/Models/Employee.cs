using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeJiraDataLibrary.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string DepartmentId { get; set; }
        public int BusinessRoleId { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string Picture { get; set; }

    }
}
