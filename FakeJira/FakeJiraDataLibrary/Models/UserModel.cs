using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeJiraDataLibrary.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? BusinessRoleId { get; set; }
        public BusinessRole BusinessRole { get; set; }
        public string Picture { get; set; }
    }
}
