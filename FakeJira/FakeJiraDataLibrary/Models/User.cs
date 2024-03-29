﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeJiraDataLibrary.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public int? BusinessRoleId { get; set; }
        [ForeignKey("BusinessRoleId")]
        public BusinessRole BusinessRole { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Picture { get; set; }

    }
}
