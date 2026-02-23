using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class ProfileTypeCreateModel
    {
        public int ProfileTypeId { get; set; }
        public string Description { get; set; }
        
    }


    public class ProfileTypeUpdateModel
    {
        public int ProfileTypeId { get; set; }
        public string Description { get; set; }
        
    }

    public class ProfileTypeViewModel
    {
        public int ProfileTypeId { get; set; }
        public string Description { get; set; }
        
    }

}
