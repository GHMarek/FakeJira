using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeJiraDataLibrary.Models
{
    public class Task
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public TaskStatus TaskStatus { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        public int AuthorId { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("AuthorId")]
        public User Author { get; set; }

        [Required]
        public int PriorityId { get; set; }

        [ForeignKey("PriorityId")]
        public TaskPriority TaskPriority { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}")]
        public DateTime DateAdded { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}")]
        public DateTime? DateClosed { get; set; }

        [Required]
        [MinLength(10), MaxLength(8000)]
        public string Contents { get; set; }


    }
}
