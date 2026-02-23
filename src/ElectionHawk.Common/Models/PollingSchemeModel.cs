using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class PollingSchemeCreateModel
    {
        public int PollingSchemeId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int ElectionId { get; set; }
        public int ConstituencyId { get; set; }
    }


    public class PollingSchemeUpdateModel
    {
        public int PollingSchemeId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int ElectionId { get; set; }
        public int ConstituencyId { get; set; }
    }

    public class PollingSchemeViewModel
    {
        public int PollingSchemeId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int ElectionId { get; set; }
        public int ConstituencyId { get; set; }
    }

}
