using System;
using System.Collections.Generic;
using System.Text;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Models
{
    public class CandidateCreateModel
    {
        public int CandidateProfileId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public byte[] Picture { get; set; }
        public int ConstituencyId { get; set; }
        public int PoliticalPartyId { get; set; }
        public int ProfileTypeId { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string MediaPresence { get; set; }
    }


    public class CandidateUpdateModel
    {
        public int CandidateProfileId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public byte[] Picture { get; set; }
        public int ConstituencyId { get; set; }
        public int PoliticalPartyId { get; set; }
        public int ProfileTypeId { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string MediaPresence { get; set; }
    }

    public class CandidateViewModel
    {
        public int CandidateProfileId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public byte[] Picture { get; set; }
        public int ConstituencyId { get; set; }
        public entity.ConstituencyEntity constituency { get; set; }
        public entity.PoliticalPartyEntity PoliticalParty { get; set; }
        public entity.ProfileTypeEntity ProfileType { get; set; }
        public int PoliticalPartyId { get; set; }
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
