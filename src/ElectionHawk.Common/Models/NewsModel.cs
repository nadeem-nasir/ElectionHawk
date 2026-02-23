using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class NewsCreateModel
    {
        public int NewsId { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Source { get; set; }
    }


    public class NewsUpdateModel
    {
        public int NewsId { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Source { get; set; }
    }

    public class NewsViewModel
    {
        public int NewsId { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Source { get; set; }
    }

}
