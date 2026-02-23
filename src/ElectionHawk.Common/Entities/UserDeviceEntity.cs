using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElectionHawk.Common.CommonEnums;

namespace ElectionHawk.Common.Entities
{
    [Table("UserDevice")]
    public class UserDeviceEntity : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int UserDeviceIdLocal { get; set; }
        public string UserDeviceRegistrationId { get; set; }
        public int? IdentityUserId { get; set; }
        public int? UserTypesId { get; set; }
        public string UserDevicePhoneName { get; set; }
        public int? UserId { get; set; }
        public DateTime? UserDeviceRegistrationDate { get; set; }
        public string UserPhoneNumber { get; set; }
        public int UserDeviceTypeId { get; set; } = (int)UserDeviceType.Andriod;
    }
}
