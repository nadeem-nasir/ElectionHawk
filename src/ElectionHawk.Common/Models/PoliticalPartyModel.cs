using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class PoliticalPartyCreateModel
    {
        public int PoliticalPartyId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public string LeaderName { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string Whatsapp { get; set; }
        public string Youtube { get; set; }
    }


    public class PoliticalPartyUpdateModel
    {
        public int PoliticalPartyId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public string LeaderName { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string Whatsapp { get; set; }
        public string Youtube { get; set; }
    }

    public class PoliticalPartyViewModel
    {
        public int PoliticalPartyId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public string LeaderName { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string Whatsapp { get; set; }
        public string Youtube { get; set; }
    }

}
