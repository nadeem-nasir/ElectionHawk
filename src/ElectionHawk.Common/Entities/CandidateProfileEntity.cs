using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("CandidateProfile")]
    public  class CandidateProfileEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateProfileId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender{ get; set; }
        public string Address { get; set; }
        public byte []Picture { get; set; }
        
        
        public int ProfileTypeId { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string MediaPresence { get; set; }
       // [ForeignKey("Constituency")]
        public int ConstituencyId { get; set; }
        public ConstituencyEntity constituency { get; set; }
        //[ForeignKey("PoliticalParty")]
        public int PoliticalPartyId { get; set; }
        public  PoliticalPartyEntity PoliticalParty { get; set; }
        public ProfileTypeEntity profileType { get; set; }

    }
}
