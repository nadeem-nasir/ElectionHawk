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
    [Route("api/news")]
    public class NewsController : BaseApiController
    {
        private readonly INewsService _newsService;
        private readonly IMapper _mapper;
        private readonly UserManager<ElectionHawkIdentityUser> _userManager;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newsService"></param>
        /// <param name="mapper"></param>
        /// <param name="userManager"></param>
        public NewsController(INewsService newsService,
            IMapper mapper, UserManager<ElectionHawkIdentityUser> userManager) : base(userManager)
        {
            this._newsService = newsService;
            this._mapper = mapper;
            this._userManager = userManager;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetNews")]
        [ProducesResponseType(typeof(model.NewsViewModel), 200)]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var item = await this._newsService.GetByIdAsync(id);
            if (item == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            var retVal = _mapper.Map<model.NewsViewModel>(item);
            return new ObjectResult(retVal);
        }
        /// <summary>
        /// Get all news
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<entity.NewsEntity>> Get()
        {
            // var user = await GetCurrentUserAsync();
            // var vt = UserRoles.Lawyers.ToString();
            // var r1 = User.IsInRole(UserRoles.Lawyers.ToString());
            // var r2 = await this._userManager.GetRolesAsync(user);
            //var rrr =  IsCurrentUserLawyer(user);

            return await this._newsService.GetAllAsync();
        }

        
        /// <summary>
        /// get news page list 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="rowsPerPage"></param>
        /// <param name="conditions"></param>
        /// <param name="orderBy"></param>
        /// <param name="parameters"></param>
        /// <param name="fields"></param>
        /// <returns></returns>

        [HttpGet("{pageNumber}/{rowsPerPage}", Name = "GetNewsPageListAsync")]
        public async Task<IActionResult> GetNewsPageListAsync([FromRoute] int pageNumber, int rowsPerPage, string conditions = null, string orderBy = "NewsTitle ASC", object parameters = null, string fields = null)
        {
            try
            {
                

                List<string> lstOfFields = new List<string>();

                if (fields != null)
                {
                    lstOfFields = fields.ToLower().Split(',').ToList();
                }

                string result = null; //await this._newsService.GetListPagedAsync(pageNumber, rowsPerPage, conditions, orderBy, parameters);

                if (result == null)
                {
                    // 404 - expenseGroup doesn't exist
                    StatusCode(StatusCodes.Status404NotFound);
                }
                return new ObjectResult(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(model.NewsCreateModel), 200)]
        public async Task<IActionResult> Create([FromBody] model.NewsCreateModel model)
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

                var entityToInsert = this._mapper.Map<entity.NewsEntity>(model);

                var affectedRow = await this._newsService.InsertAsync(entityToInsert);

                if (affectedRow.HasValue && affectedRow.Value > 0)
                {
                    model.NewsId = affectedRow.Value;
                    return CreatedAtRoute("GetNews", new { id = model.NewsId }, model);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/News/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(model.NewsUpdateModel), 200)]
        public async Task<IActionResult> Put([FromBody]model.NewsUpdateModel model)
        {
            try
            {
                if (model == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                //var searchResult = await this._newsService.GetByIdAsync(model.NewsId);
                //if (searchResult == null)
                //{
                //    return StatusCode(StatusCodes.Status404NotFound);
                //}
                var entityToUpdate = this._mapper.Map<entity.NewsEntity>(model);
                var result = await this._newsService.UpdateAsync(entityToUpdate);
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
        [HttpDelete("{id}", Name = "DeleteNews")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                var searchResult = await this._newsService.GetByIdAsync(id);
                if (searchResult == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                var result = await this._newsService.DeleteByIdAsync(id);
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
