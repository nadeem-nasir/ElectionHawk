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
    [Route("api/election")]
    public class ElectionController : BaseApiController
    {
        private readonly IElectionService _electionService;
        private readonly IMapper _mapper;
        private readonly UserManager<ElectionHawkIdentityUser> _userManager;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="electionService"></param>
        /// <param name="mapper"></param>
        /// <param name="userManager"></param>

        public ElectionController(IElectionService electionService,
            IMapper mapper, UserManager<ElectionHawkIdentityUser> userManager) : base(userManager)
        {
            this._electionService = electionService;
            this._mapper = mapper;
            this._userManager = userManager;
        }
		/// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<entity.ElectionEntity>> Get()
        {
            return await this._electionService.GetAllAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetElection")]
        [ProducesResponseType(typeof(model.ElectionViewModel), 200)]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var item = await this._electionService.GetByIdAsync(id);
            if (item == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            var retVal = _mapper.Map<model.ElectionViewModel>(item);
            return new ObjectResult(retVal);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(model.ElectionCreateModel), 200)]
        public async Task<IActionResult> Create([FromBody] model.ElectionCreateModel model)
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

                var entityToInsert = this._mapper.Map<entity.ElectionEntity>(model);

                var affectedRow = await this._electionService.InsertAsync(entityToInsert);

                if (affectedRow.HasValue && affectedRow.Value > 0)
                {
                    model.ElectionId = affectedRow.Value;
                    return CreatedAtRoute("GetElection", new { id = model.ElectionId }, model);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Election/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(model.ElectionUpdateModel), 200)]
        public async Task<IActionResult> Put([FromBody]model.ElectionUpdateModel model)
        {
            try
            {
                if (model == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                //var searchResult = await this._electionService.GetByIdAsync(model.ElectionId);
                //if (searchResult == null)
                //{
                //    return StatusCode(StatusCodes.Status404NotFound);
                //}
                var entityToUpdate = this._mapper.Map<entity.ElectionEntity>(model);
                var result = await this._electionService.UpdateAsync(entityToUpdate);
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
        [HttpDelete("{id}", Name = "DeleteElection")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                var searchResult = await this._electionService.GetByIdAsync(id);
                if (searchResult == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                var result = await this._electionService.DeleteByIdAsync(id);
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
