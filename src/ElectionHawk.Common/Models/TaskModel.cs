using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class TaskCreateModel
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public string TaskType { get; set; }
        public DateTime CreatedDate { get; set; }
    }


    public class TaskUpdateModel
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public string TaskType { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class TaskViewModel
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public string TaskType { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
