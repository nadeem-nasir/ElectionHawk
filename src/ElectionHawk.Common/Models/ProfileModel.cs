using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class ProfileCreateModel
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public string FatherName { get; set; }
        public string SpouseName { get; set; }
        public string GuardianName { get; set; }
        public string Address { get; set; }
        public byte[] Picture { get; set; }
        public int ConstituencyId { get; set; }
        public int AffiliatedPoliticalPartyId { get; set; }
        public int ProfileTypeId { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string MediaPresence { get; set; }
    }


    public class ProfileUpdateModel
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public string FatherName { get; set; }
        public string SpouseName { get; set; }
        public string GuardianName { get; set; }
        public string Address { get; set; }
        public byte[] Picture { get; set; }
        public int ConstituencyId { get; set; }
        public int AffiliatedPoliticalPartyId { get; set; }
        public int ProfileTypeId { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string MediaPresence { get; set; }
    }

    public class ProfileViewModel
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public string FatherName { get; set; }
        public string SpouseName { get; set; }
        public string GuardianName { get; set; }
        public string Address { get; set; }
        public byte[] Picture { get; set; }
        public int ConstituencyId { get; set; }
        public int AffiliatedPoliticalPartyId { get; set; }
        public int ProfileTypeId { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string MediaPresence { get; set; }
    }

}
