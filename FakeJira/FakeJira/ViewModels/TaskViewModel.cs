using FakeJiraDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeJira.ViewModels
{
    public class TaskViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<TaskPriority> TaskPriority { get; set; }
        public IEnumerable<TaskStatus> TaskStatus { get; set; }
        public Task Task { get; set; }

    }
}