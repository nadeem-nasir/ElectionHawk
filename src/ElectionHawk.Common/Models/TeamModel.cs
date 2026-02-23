using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class TeamCreateModel
    {
        public int TeamId { get; set; }
        public string TeamTitle { get; set; }
        public int AreaId { get; set; }
        public int TaskId { get; set; }
    }


    public class TeamUpdateModel
    {
        public int TeamId { get; set; }
        public string TeamTitle { get; set; }
        public int AreaId { get; set; }
        public int TaskId { get; set; }
    }

    public class TeamViewModel
    {
        public int TeamId { get; set; }
        public string TeamTitle { get; set; }
        public int AreaId { get; set; }
        public int TaskId { get; set; }
    }

}
