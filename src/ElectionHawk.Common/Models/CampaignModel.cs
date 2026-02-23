using System;
using System.Collections.Generic;
using System.Text;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Models
{
    public class CampaignCreateModel
    {
        public int CampaignId { get; set; }
        public string Title { get; set; }
        public string Media { get; set; }
        public string MediumofPropagation { get; set; }
        public int AgendaId { get; set; }
        public string Forum { get; set; }
    }


    public class CampaignUpdateModel
    {
        public int CampaignId { get; set; }
        public string Title { get; set; }
        public string Media { get; set; }
        public string MediumofPropagation { get; set; }
        public int AgendaId { get; set; }
        public string Forum { get; set; }
    }

    public class CampaignViewModel
    {
        public int CampaignId { get; set; }
        public string Title { get; set; }
        public string Media { get; set; }
        public string MediumofPropagation { get; set; }
        public int AgendaId { get; set; }

        public string Forum { get; set; }
        public virtual entity.AgendaItemEntity agendaItemEntity { get; set; }
    }

}
