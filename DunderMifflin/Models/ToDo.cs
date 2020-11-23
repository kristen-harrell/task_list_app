using System;
using System.Collections.Generic;

namespace DunderMifflin.Models
{
    public partial class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }
    }
}
