using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionHawk.Web
{
    public class ElectionHawkIdentityRole:IdentityRole<int>
    {
        [StringLength(250)]
        public string Description { get; set; }
    }
}
