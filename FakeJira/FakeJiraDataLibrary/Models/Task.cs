﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int EmployeeAsgnId { get; set; }
        [Required]
        public int PriorityId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd MM yyyy}")]
        public DateTime DateAdded { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd MM yyyy}")]
        public DateTime? DateClosed { get; set; }


    }
}