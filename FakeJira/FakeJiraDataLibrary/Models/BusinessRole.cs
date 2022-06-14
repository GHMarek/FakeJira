using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeJiraDataLibrary.Models
{
    public class BusinessRole
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Manager { get; set; }
        public int ParentManagerId { get; set; }

    }
}
