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
    [Route("api/voterlist")]
    public class VoterListController : BaseApiController
    {
        private readonly IVotersListService _voterListService;
        private readonly IMapper _mapper;
        private readonly UserManager<ElectionHawkIdentityUser> _userManager;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="voterListService"></param>
        /// <param name="mapper"></param>
        /// <param name="userManager"></param>
        public VoterListController(IVotersListService voterListService,
            IMapper mapper, UserManager<ElectionHawkIdentityUser> userManager) : base(userManager)
        {
            this._voterListService = voterListService;
            this._mapper = mapper;
            this._userManager = userManager;
        }
		/// <summary>
        /// 
        /// </summary>
        /// 
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<entity.VotersListEntity>> Get()
        {
            
			return await this._voterListService.GetAllAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetVoterList")]
        [ProducesResponseType(typeof(model.VotersListViewModel), 200)]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var item = await this._voterListService.GetByIdAsync(id);
            if (item == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            var retVal = _mapper.Map<model.VotersListViewModel>(item);
            return new ObjectResult(retVal);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(model.VotersListCreateModel), 200)]
        public async Task<IActionResult> Create([FromBody] model.VotersListCreateModel model)
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

                var entityToInsert = this._mapper.Map<entity.VotersListEntity>(model);

                var affectedRow = await this._voterListService.InsertAsync(entityToInsert);

                if (affectedRow.HasValue && affectedRow.Value > 0)
                {
                    model.VoterListId = affectedRow.Value;
                    return CreatedAtRoute("GetVoterList", new { id = model.VoterListId }, model);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/VoterList/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(model.VotersListUpdateModel), 200)]
        public async Task<IActionResult> Put([FromBody]model.VotersListUpdateModel model)
        {
            try
            {
                if (model == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                //var searchResult = await this._voterListService.GetByIdAsync(model.VoterListId);
                //if (searchResult == null)
                //{
                //    return StatusCode(StatusCodes.Status404NotFound);
                //}
                var entityToUpdate = this._mapper.Map<entity.VotersListEntity>(model);
                var result = await this._voterListService.UpdateAsync(entityToUpdate);
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
        [HttpDelete("{id}", Name = "DeleteVoterList")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                var searchResult = await this._voterListService.GetByIdAsync(id);
                if (searchResult == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                var result = await this._voterListService.DeleteByIdAsync(id);
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
