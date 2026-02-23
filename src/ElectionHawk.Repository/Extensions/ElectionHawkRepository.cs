using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using ElectionHawk.Common.Interfaces;
using ElectionHawk.Repository;

namespace ElectionHawk.Repository
{
    public static class ElectionHawkRepository
    {
        public static IServiceCollection AddCElectionHawkRepository(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryBase, RepositoryBase>();
            services.AddTransient<IAgendaItemRepository, AgendaItemRepository>();
            services.AddTransient<ICampaignRepository, CampaignRepository>();
            services.AddTransient<ICandidateAgendaRepository, CandidateAgendaRepository>();
            services.AddTransient<ICandidateAgendaItemRepository, CandidateAgendaItemRepository>();
            services.AddTransient<ICandidateCampaignOfficeRepository, CandidateCampaignOfficeRepository>();

            services.AddTransient<ICandidateConstituencyOpponentsRepository, CandidateConstituencyOpponentsRepository>();

            services.AddTransient<ICandidateConstituencyRepository, CandidateConstituencyRepository>();

            services.AddTransient<ICandidateDocumentRepository, CandidateDocumentRepository>();

            services.AddTransient<ICandidateEventRepository, CandidateEventRepository>();

            services.AddTransient<ICandidateGroupsRepository, CandidateGroupsRepository>();


            services.AddTransient<ICandidateProfileRepository, CandidateProfileRepository>();

            services.AddTransient<ICandidateSupporterRepository, CandidateSupporterRepository>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<ICityRepository, CityRepository>();

            services.AddTransient<IConstituencyRepository, ConstituencyRepository>();

            services.AddTransient<IConstituencyTypeRepository, ConstituencyTypeRepository>();

            services.AddTransient<IConstituencyVoterListRepository, ConstituencyVoterListRepository>();

            services.AddTransient<ICountryRepository, CountryRepository>();

            services.AddTransient<IDistrictConstituencyRepository, DistrictConstituencyRepository>();

            services.AddTransient<IDistrictRepository, DistrictRepository>();

            services.AddTransient<IElectionRepository, ElectionRepository>();

            services.AddTransient<IElectionResultRepository, ElectionResultRepository>();

            services.AddTransient<IElectionTypeRepository, ElectionTypeRepository>();

            services.AddTransient<IEventRepository, EventRepository>();

            services.AddTransient<IExpenseRepository, ExpenseRepository>();

            services.AddTransient<IMapRepository, MapRepository>();

            services.AddTransient<INewsRepository, NewsRepository>();

            services.AddTransient<INotificationRepository, NotificationRepository>();

            services.AddTransient<IPartyOfficeRepository, PartyOfficeRepository>();

            services.AddTransient<IPoliticalPartyDesignationRepository, PoliticalPartyDesignationRepository>();
            services.AddTransient<IPoliticalPartyOfficialMemberRepository, PoliticalPartyOfficialMemberRepository>();




            services.AddTransient<IPoliticalPartyRepository, PoliticalPartyRepository>();


            services.AddTransient<IPollingSchemeRepository, PollingSchemeRepository>();

            services.AddTransient<IPollingSchemeStationRepository, PollingSchemeStationRepository>();


            services.AddTransient<IPollingStationBoothAgentRepository, PollingStationBoothAgentRepository>();



            services.AddTransient<IPollingStationBoothResultFormRepository, PollingStationBoothResultFormRepository>();

            services.AddTransient<IPollingStationBoothResultRepository, PollingStationBoothResultRepository>();


            services.AddTransient<IPollingStationInfoRepository, PollingStationInfoRepository>();


            services.AddTransient<IPollingStationTokenAgentRepository, PollingStationTokenAgentRepository>();

            services.AddTransient<IProfileRepository, ProfileRepository>();

            services.AddTransient<IProfileTypeRepository, ProfileTypeRepository>();

            services.AddTransient<IProvinceRepository, ProvinceRepository>();

            services.AddTransient<ISMSCampaignRepository, SMSCampaignRepository>();

            services.AddTransient<ITargetCommunityRepository, TargetCommunityRepository>();

            services.AddTransient<ITaskRepository, TaskRepository>();

            services.AddTransient<ITeamMemberRepository, TeamMemberRepository>();

            services.AddTransient<ITeamRepository, TeamRepository>();

            services.AddTransient<ITeamTaskRepository, TeamTaskRepository>();

            services.AddTransient<IVoterListDetailRepository, VoterListDetailRepository>();

            services.AddTransient<IVotersListRepository, VotersListRepository>();

            services.AddTransient<IUserDeviceRepository, UserDeviceRepository>();

            return services;
        }
    }
}
