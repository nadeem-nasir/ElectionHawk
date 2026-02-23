using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionHawk.Web.Identity
{
    public class ApplicationUserPhoto
    {
        [Key]
        public int Id { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public int ApplicationUserId { get; set; }
        public ElectionHawkIdentityUser ApplicationUser { get; set; }
    }
}
