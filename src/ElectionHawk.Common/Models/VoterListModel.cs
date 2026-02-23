using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class VotersListCreateModel
    {
        public int VoterListId { get; set; }
        public string VoterListTitle { get; set; }
        public string VoterListType { get; set; }
        public int TargetCommunityId { get; set; }
    }


    public class VotersListUpdateModel
    {
        public int VoterListId { get; set; }
        public string VoterListTitle { get; set; }
        public string VoterListType { get; set; }
        public int TargetCommunityId { get; set; }
    }

    public class VotersListViewModel
    {
        public int VoterListId { get; set; }
        public string VoterListTitle { get; set; }
        public string VoterListType { get; set; }
        public int TargetCommunityId { get; set; }
    }

}
