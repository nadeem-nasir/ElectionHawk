using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.CommonEnums
{
   
    public enum ConstituencyType
    {

        NA = 1, 
        PA= 2
    }

    public enum ElectionType
    {
        GeneralParliamentElection = 1,
        LocalGovernmentElection = 2
    }

    public enum UserRoles
    {
        User = 1,
        PollingAgent = 2,
        TokenAgent = 3,
        Candidate = 4,
        CampaignManager = 5,
        Votter = 6,
        Administrator = 7,
        Supporter = 8,
        GeneralPublic = 9,
        Marketing = 10,
        Guest = 11
    }

    public enum UserDeviceType
    {
        Andriod = 1,
        Iphone = 2
    }
}
