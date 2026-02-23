using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ElectionHawk.Repository;
using ElectionHawk.Service.Interfaces;

namespace ElectionHawk.Service.Extensions
{
    public static class ElectionHawkService
    {
        public static IServiceCollection AddCElectionHawkService(this IServiceCollection services)
        {
            services.AddCElectionHawkRepository();
            //todo base service and try to register with base class 
            services.AddTransient<IPoliticalPartyService, PoliticalPartyService>();
            services.AddTransient<IConstituencyService, ConstituencyService>();
            services.AddTransient<IAgendaItemService, AgendaItemService>();
            services.AddTransient<ICampaignService, CampaignService>();
            services.AddTransient<ICandidateAgendaItemService, CandidateAgendaItemService>();
            services.AddTransient<ICandidateAgendaService, CandidateAgendaService>();
            services.AddTransient<ICandidateCampaignOfficeService, CandidateCampaignOfficeService>();
            services.AddTransient<ICandidateCampaignService, CandidateCampaignService>();
            services.AddTransient<ICandidateCampaignVehicleService, CandidateCampaignVehicleService>();
            services.AddTransient<ICandidateConstituencyOpponentsService, CandidateConstituencyOpponentsService>();
            services.AddTransient<ICandidateConstituencyService, CandidateConstituencyService>();
            services.AddTransient<ICandidateDocumentService, CandidateDocumentService>();
            services.AddTransient<ICandidateEventService, CandidateEventService>();
            services.AddTransient<ICandidateGroupsService, CandidateGroupsService>();
            services.AddTransient<ICandidateNewsService, CandidateNewsService>();
            services.AddTransient<ICandidateProfileService, CandidateProfileService>();
            services.AddTransient<ICandidateSMSService, CandidateSMSService>();
            services.AddTransient<ICandidateSupporterService, CandidateSupporterService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IConstituencyTypeService,ConstituencyTypeService>();
            services.AddTransient<IConstituencyVoterListService, ConstituencyVoterListService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IDistrictConstituencyService, DistrictConstituencyService>();
            services.AddTransient<IDistrictService, DistrictService>();
            services.AddTransient<IElectionResultService, ElectionResultService>();
            services.AddTransient<IElectionService, ElectionService>();
            services.AddTransient<IElectionTypeService, ElectionTypeService>();
            services.AddTransient<IExpenseService, ExpenseService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IPoliticalPartyDesignationService, PoliticalPartyDesignationService>();
            services.AddTransient<IPartyOfficeService, PartyOfficeService>();
            services.AddTransient<IPictureService, PictureService>();
            services.AddTransient<IPoliticalPartyOfficialMemberService, PoliticalPartyOfficialMemberService>();
            services.AddTransient<IPollingSchemeService, PollingSchemeService>();
            services.AddTransient<IPollingSchemeStationService, PollingSchemeStationService>();
            services.AddTransient<IPollingStationBoothAgentService, PollingStationBoothAgentService>();
            services.AddTransient<IPollingStationBoothResultFormService, PollingStationBoothResultFormService>();
            services.AddTransient<IPollingStationBoothResultService, PollingStationBoothResultService>();
            services.AddTransient<IPollingStationInfoService, PollingStationInfoService >();
            services.AddTransient<IPollingStationTokenAgentService, PollingStationTokenAgentService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IProfileTypeService, ProfileTypeService>();
            services.AddTransient<IProvinceService, ProvinceService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IMapService, MapService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<ISMSCampaignService, SMSCampaignService>();
            services.AddTransient<ITargetCommunityService, TargetCommunityService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITeamMemberService, TeamMemberService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<ITeamTaskService, TeamTaskService>();
            services.AddTransient<IUserDeviceService, UserDeviceService>();
            services.AddTransient<IVoterListDetailService, VoterListDetailService>();
            services.AddTransient<IVotersListService, VotersListService>();
            
            return services;
        }
    }
}
