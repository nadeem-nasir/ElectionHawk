/* News interface */
export interface INews {
    newsId: number;
    heading: string;
    description: string;
    status: string;
    publishedDate: Date;
    createdDate: Date;
    source: string;
}
export interface IElection {
    ElectionId: number;
    ElectionName: string;
}
/* Using in notifications service */
export interface Predicate<T> {
    (item: T): boolean
}

/*user and authentications service, login etc */

export interface IUserTokenResponse
{
    Code: string;
    Message: string;
    Data: IUserToken;
}

export interface IUserToken
{
    access_token: string;
    expires_in: number;
    tokey_type: string;
    refresh_token:string
}

//CurrentUserInfo
export interface ICurrentUserInfo
{
    currentUserFullName: string;
    currentUserName: string;
    currentUserEmail: string;
    currentUserId: number;
    currentUserExpiryDateTime: string;
    isCurrentUserExpiry: boolean;
    isCurrentUserCorporateClient: boolean;
    isCurrentUserLawyersOrClerk: boolean;
}
//end CurrentUserInfo
export interface IUpdateUserPurchaseInfo
{
    securityCode: string;
}
/* */

export interface IAgenda{
	itemId: number;
	description:string;
}
/*News Letters Subscriptions*/
export interface ICampaign{
    campaignId: number;
    title: string;
    media: string;
    mediumofPropagation: string;
    agendaId: number;
    forum: string;
	agendaItemEntity:IAgenda;

}

/*Courts*/
export interface ICandidate {
    candidateProfileId: number;
    name: string;
    age: number;
    gender: boolean;
    address: string;
    picture: ByteString;
    constituencyId: number;
	constituency: IConstituency;
	politicalParty: IPoliticalParty;
    profileType: IProfileType;
    phone1: string;
    phone2: string;
    email: string;
    whatsapp: string;
    facebookUrl: string;
    twitterUrl: string;
    mediaPresence: string;
}
/*City */
export interface ICity{
    cityId: number;
    cityName: string;
    

}
/*Clerck*/
export interface IConstituency {
    constituencyId: number;
    constituencyTypeId: number;
    constituencyTitle: string;
    constituencyName: string;
    mapId: number;
    areaId: number;
    cityId: number;
    districtId: number;
    provinceId: number;
    ecpConstCode: number;
}

export interface INotification{
    NotificationId: number;
    Description: string;
}

/*Client**/
export interface IPoliticalParty {
    PoliticalPartyId: number;
    name: string;
    abbreviation: string;
    description: string;
    leaderName: string;
    designation: string;
    address: string;
    website: string;
    facebookUrl: string;
    twitterUrl: string;
    whatsapp: string;
    youTube: string;
}

export interface IPollingScheme{
    StationId: number;
    stationName: string; 
    maleBooths: number;
    femaleBooths: number; 
    totalBooths: number; 
    maleVoters: number; 
    femaleVoters: number; 
    totalVoters: number;
    latitude: Float32Array;
    longitude: Float32Array;
    pollingStationImageUrl: string; 
    pollingStationMapUrl: string;      
    eCPPSNo: number; 

}

/*  profile*/
export interface IProfile{
    ProfileId: number; 
    Name: string; 
    Age: number;
    Gender: boolean;
    FatherName: string;
    SpouseName: string; 
    GuardianName: string;
    Address: string;
    Picture: ByteString[];
    ConstituencyId: string; 
    AffiliatedPoliticalPartyId: number;
    ProfileTypeId: number;
    Phone1: string;
    Phone2: string;
    Email: string;
    Whatsapp: string;
    FacebookUrl: string;
    TwitterUrl: string;
    MediaPresence: string;

}

export interface IMap{
    mapId: number;
    locationTitle: string;
    locationPoints: string;
    
}
/* 
 styleClass?: string;
*/

/*end Lawyer profile */

export interface IEmail {
    emailId: number;
    emailValue: string;
}
export interface IAddress {
    addressId: number;
    addressCompleteDetail: string;

}
export interface IPhone {
    phoneId: number;
    phoneNumber: string;
}


export interface IVotersList{
    VoterListId: number;
    VoterListTitle: string;
    VoterListType: string;
    TargetCommunityId: number;

    
}

export interface IEvent{
    eventId: number;
    name: string;
    description: string;
    areaId: number;
    venue: string;
    heldOn: Date; 
    agenda: string; 
	ItemId:IAgenda;
    organizerProfileId: IProfile;
	organizer:string;
    chiefGuestProfileId: IProfile;
	guest:string;
}


export interface IExpense{
    ExpenseId: number;
    EventId: number;
    AmountUtilized: number;
    TotalBudget: number;
    Balance: number;
    ExpenseType: number;
    Description: string;
    ManagerProfileId: number;
}
export interface IProfileType{
	profileTypeId: number;
	description:string;
	
}
