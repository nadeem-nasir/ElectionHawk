using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class ElectionCreateModel
    {
        public int ElectionId { get; set; }
        public string ElectionName { get; set; }
    }


    public class ElectionUpdateModel
    {
        public int ElectionId { get; set; }
        public string ElectionName { get; set; }
    }

    public class ElectionViewModel
    {
        public int ElectionId { get; set; }
        public string ElectionName { get; set; }
    }

}
