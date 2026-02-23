using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ElectionHawk.Service.Interfaces;
using model = ElectionHawk.Common.Models;
using entity = ElectionHawk.Common.Entities;
using AutoMapper;
using ElectionHawk.Web.Helpers;
using Microsoft.AspNetCore.Identity;

namespace ElectionHawk.Web.Controllers.ApiControllers
{
    [Produces("application/json")]
    [Route("api/campaign")]
    public class CampaignController : BaseApiController
    {
        private readonly ICampaignService _campaignService;
        private readonly IMapper _mapper;
        private readonly UserManager<ElectionHawkIdentityUser> _userManager;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="campaignService"></param>
        /// <param name="mapper"></param>
        /// <param name="userManager"></param>
        public CampaignController(ICampaignService campaignService,
            IMapper mapper, UserManager<ElectionHawkIdentityUser> userManager):base(userManager)
        {
            this._campaignService = campaignService;
            this._mapper = mapper;
            this._userManager = userManager;
        }
        /// <summary>
        /// Get all news
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<entity.CampaignEntity>> Get()
        {
            // var user = await GetCurrentUserAsync();
            // var vt = UserRoles.Lawyers.ToString();
            // var r1 = User.IsInRole(UserRoles.Lawyers.ToString());
            // var r2 = await this._userManager.GetRolesAsync(user);
            //var rrr =  IsCurrentUserLawyer(user);

            return await this._campaignService.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetCampaign")]
        [ProducesResponseType(typeof(model.CampaignViewModel), 200)]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            try
            {
                var item = await this._campaignService.GetByIdAsync(id);
                if (item == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                var retVal = _mapper.Map<model.CampaignViewModel>(item);
                return new ObjectResult(retVal);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(model.CampaignCreateModel), 200)]
        public async Task<IActionResult> Create([FromBody] model.CampaignCreateModel model)
        {
            try
            {
                if (model == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                if (!ModelState.IsValid)
                {
                    //422 UnprocessabEntity with list of errors
                    return new UnprocessabEntityObjectResult(ModelState);
                }

                var entityToInsert = this._mapper.Map<entity.CampaignEntity>(model);

                var affectedRow = await this._campaignService.InsertAsync(entityToInsert);

                if (affectedRow.HasValue && affectedRow.Value > 0)
                {
                    model.CampaignId = affectedRow.Value;
                    return CreatedAtRoute("GetCampaign", new { id = model.CampaignId }, model);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Campaign/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(model.CampaignUpdateModel), 200)]
        public async Task<IActionResult> Put([FromBody]model.CampaignUpdateModel model)
        {
            try
            {
                if (model == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                //var searchResult = await this._campaignService.GetByIdAsync(model.CampaignId);
                //if (searchResult == null)
                //{
                //    return StatusCode(StatusCodes.Status404NotFound);
                //}
                var entityToUpdate = this._mapper.Map<entity.CampaignEntity>(model);
                var result = await this._campaignService.UpdateAsync(entityToUpdate);
                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteCampaign")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                var searchResult = await this._campaignService.GetByIdAsync(id);
                if (searchResult == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                var result = await this._campaignService.DeleteByIdAsync(id);
                if (result)
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
