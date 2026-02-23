using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class AgendaCreateModel
    {
        public int ItemId { get; set; }
        public string Description { get; set; }
    }


    public class AgendaUpdateModel
    {
        public int ItemId { get; set; }
        public string Description { get; set; }
    }

    public class AgendaViewModel
    {
        public int ItemId { get; set; }
        public string Description { get; set; }
    }

}
