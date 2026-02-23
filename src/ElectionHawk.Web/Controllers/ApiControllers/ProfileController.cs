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
    [Route("api/profile")]
    public class ProfileController : BaseApiController
    {
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper;
        private readonly UserManager<ElectionHawkIdentityUser> _userManager;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="profileService"></param>
        /// <param name="mapper"></param>
        /// <param name="userManager"></param>
        public ProfileController(IProfileService profileService,
            IMapper mapper, UserManager<ElectionHawkIdentityUser> userManager) : base(userManager)
        {
            this._profileService = profileService;
            this._mapper = mapper;
            this._userManager = userManager;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetProfile")]
        [ProducesResponseType(typeof(model.ProfileViewModel), 200)]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var item = await this._profileService.GetByIdAsync(id);
            if (item == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            var retVal = _mapper.Map<model.ProfileViewModel>(item);
            return new ObjectResult(retVal);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(model.ProfileCreateModel), 200)]
        public async Task<IActionResult> Create([FromBody] model.ProfileCreateModel model)
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

                var entityToInsert = this._mapper.Map<entity.ProfileEntity>(model);

                var affectedRow = await this._profileService.InsertAsync(entityToInsert);

                if (affectedRow.HasValue && affectedRow.Value > 0)
                {
                    model.ProfileId = affectedRow.Value;
                    return CreatedAtRoute("GetProfile", new { id = model.ProfileId }, model);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Profile/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(model.ProfileUpdateModel), 200)]
        public async Task<IActionResult> Put([FromBody]model.ProfileUpdateModel model)
        {
            try
            {
                if (model == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                //var searchResult = await this._profileService.GetByIdAsync(model.ProfileId);
                //if (searchResult == null)
                //{
                //    return StatusCode(StatusCodes.Status404NotFound);
                //}
                var entityToUpdate = this._mapper.Map<entity.ProfileEntity>(model);
                var result = await this._profileService.UpdateAsync(entityToUpdate);
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
        [HttpDelete("{id}", Name = "DeleteProfile")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                var searchResult = await this._profileService.GetByIdAsync(id);
                if (searchResult == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                var result = await this._profileService.DeleteByIdAsync(id);
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
