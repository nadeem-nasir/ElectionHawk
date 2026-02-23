using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ElectionHawk.Web.Crawlers;
using ElectionHawk.Service.Interfaces;
using model = ElectionHawk.Common.Models;
using entity = ElectionHawk.Common.Entities;
using AutoMapper;
using ElectionHawk.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using ElectionHawk.Web.Controllers.ApiControllers;

namespace ElectionHawk.Web.Controllers.WebControllers
{
    [Produces("application/json")]
    [Route("api/Values")]
    //[Route("api/Values")]
    //[ApiVersion("2.0")]
    public class Values2Controller : Controller
    {
        private readonly IConstituencyService _constituencyService;
        public Values2Controller(IConstituencyService constituencyService)
        {

            this._constituencyService = constituencyService;
        }

        // GET: api/Values2
        [HttpGet(Name = "GetV2")]
        public IEnumerable<string> Get()
        {
            CrawlerConstituencyAndPollingsSheme spider = new CrawlerConstituencyAndPollingsSheme();
            // var nationalAssemblyConstituencyUrl =  spider.ScrapNationalAssemblyConstituencyUrl("https://www.ecp.gov.pk/frmGISPublish.aspx?type=NA");
            //var provincialAssemblyConstituencyUrl=   spider.ScrapProvincialAssemblyConstituencyUrl("https://www.ecp.gov.pk/frmGISPublish.aspx?type=PA");
            //Then download polling scheme for each link using this method
            //get one Constituency
            //var constituency = spider.ScrapPollingsSheme("https://www.ecp.gov.pk/frmPSGE.aspx?ProvCode=9&ConstCode=4&ElectionType=NA", "blog-content");

            //_constituencyService.SqlBulkCopy(constituency);

            return new string[] { "value2.0", "value2.0" };
        }

        // GET: api/Values2/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Values2
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Values2/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Authorize]
        [HttpGet("claims")]
        public object Claims()
        {
            var db = User.Claims.Select(c =>
            new
            {
                Type = c.Type,
                Value = c.Value
            });
            return User.Claims.Select(c =>
            new
            {
                Type = c.Type,
                Value = c.Value
            });
        }
    }
}
