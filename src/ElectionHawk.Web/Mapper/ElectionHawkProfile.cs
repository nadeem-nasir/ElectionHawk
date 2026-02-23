using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using model = ElectionHawk.Common.Models;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Web
{
    public class ElectionHawkProfile: Profile
    {
        public ElectionHawkProfile ()
        {
            CreateMap<model.PoliticalPartyCreateModel, entity.PoliticalPartyEntity >();
            CreateMap<model.PoliticalPartyUpdateModel, entity.PoliticalPartyEntity>();
            CreateMap<entity.PoliticalPartyEntity, model.PoliticalPartyViewModel>();

            CreateMap<model.AgendaCreateModel, entity.AgendaItemEntity>();
            CreateMap<model.AgendaUpdateModel, entity.AgendaItemEntity>();
            CreateMap<entity.AgendaItemEntity, model.AgendaViewModel>();

            CreateMap<model.CampaignCreateModel, entity.CampaignEntity>();
            CreateMap<model.CampaignUpdateModel, entity.CampaignEntity>();
            CreateMap<entity.CampaignEntity, model.CampaignViewModel>();

            CreateMap<model.CandidateCreateModel, entity.CandidateProfileEntity>();
            CreateMap<model.CandidateUpdateModel, entity.CandidateProfileEntity>();
            CreateMap<entity.CandidateProfileEntity, model.CandidateViewModel>();

            CreateMap<model.CategoryCreateModel, entity.CategoryEntity>();
            CreateMap<model.CategoryUpdateModel, entity.CategoryEntity>();
            CreateMap<entity.CategoryEntity, model.CategoryViewModel>();

            CreateMap<model.CityCreateModel, entity.CityEntity>();
            CreateMap<model.CityUpdateModel, entity.CityEntity>();
            CreateMap<entity.CityEntity, model.CityViewModel>();

            CreateMap<model.ConstituencyCreateModel, entity.ConstituencyEntity>();
            CreateMap<model.ConstituencyUpdateModel, entity.ConstituencyEntity>();
            CreateMap<entity.ConstituencyEntity, model.ConstituencyViewModel>();

            CreateMap<model.CountryCreateModel, entity.CountryEntity>();
            CreateMap<model.CountryUpdateModel, entity.CountryEntity>();
            CreateMap<entity.CountryEntity, model.CountryViewModel>();

            CreateMap<model.DistrictCreateModel, entity.DistrictEntity>();
            CreateMap<model.DistrictUpdateModel, entity.DistrictEntity>();
            CreateMap<entity.DistrictEntity, model.DistrictViewModel>();

            CreateMap<model.ElectionCreateModel, entity.ElectionEntity>();
            CreateMap<model.ElectionUpdateModel, entity.ElectionEntity>();
            CreateMap<entity.ElectionEntity, model.ElectionViewModel>();

            CreateMap<model.EventCreateModel, entity.EventEntity>();
            CreateMap<model.EventUpdateModel, entity.EventEntity>();
            CreateMap<entity.EventEntity, model.EventViewModel>();

            CreateMap<model.ExpenseCreateModel, entity.ExpenseEntity>();
            CreateMap<model.ExpenseUpdateModel, entity.ExpenseEntity>();
            CreateMap<entity.ExpenseEntity, model.ExpenseViewModel>();

            CreateMap<model.MapCreateModel, entity.MapEntity>();
            CreateMap<model.MapUpdateModel, entity.MapEntity>();
            CreateMap<entity.MapEntity, model.MapViewModel>();


            CreateMap<model.NewsCreateModel, entity.NewsEntity>();
            CreateMap<model.NewsUpdateModel, entity.NewsEntity>();
            CreateMap<entity.NewsEntity, model.NewsViewModel>();

            CreateMap<model.NotificationCreateModel, entity.NotificationEntity>();
            CreateMap<model.NotificationUpdateModel, entity.NotificationEntity>();
            CreateMap<entity.NotificationEntity, model.NotificationViewModel>();

            CreateMap<model.PollingSchemeCreateModel, entity.PollingSchemeEntity>();
            CreateMap<model.PollingSchemeUpdateModel, entity.PollingSchemeEntity>();
            CreateMap<entity.PollingSchemeEntity, model.PollingSchemeViewModel>();

            CreateMap<model.PollingSchemeStationCreateModel, entity.PollingSchemeStationEntity>();
            CreateMap<model.PollingSchemeStationUpdateModel, entity.PollingSchemeStationEntity>();
            CreateMap<entity.PollingSchemeStationEntity, model.PollingSchemeStationViewModel>();

            CreateMap<model.ProfileCreateModel, entity.ProfileEntity>();
            CreateMap<model.ProfileUpdateModel, entity.ProfileEntity>();
            CreateMap<entity.ProfileEntity, model.ProfileViewModel>();

            CreateMap<model.ProvinceCreateModel, entity.ProvinceEntity>();
            CreateMap<model.ProvinceUpdateModel, entity.ProvinceEntity>();
            CreateMap<entity.ProvinceEntity, model.ProvinceViewModel>();

            CreateMap<model.TaskCreateModel, entity.TaskEntity>();
            CreateMap<model.TaskUpdateModel, entity.TaskEntity>();
            CreateMap<entity.TaskEntity, model.TaskViewModel>();

            CreateMap<model.TeamCreateModel, entity.TeamEntity>();
            CreateMap<model.TeamUpdateModel, entity.TeamEntity>();
            CreateMap<entity.TeamEntity, model.TeamViewModel>();

            CreateMap<model.VotersListCreateModel, entity.VotersListEntity>();
            CreateMap<model.VotersListUpdateModel, entity.VotersListEntity>();
            CreateMap<entity.VotersListEntity, model.VotersListViewModel>();
        }
    }
}
