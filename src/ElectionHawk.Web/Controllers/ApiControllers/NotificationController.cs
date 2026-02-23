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
    [Route("api/notification")]
    public class NotificationController : BaseApiController
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly UserManager<ElectionHawkIdentityUser> _userManager;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notificationService"></param>
        /// <param name="mapper"></param>
        /// <param name="userManager"></param>
        public NotificationController(INotificationService notificationService,
            IMapper mapper, UserManager<ElectionHawkIdentityUser> userManager) : base(userManager)
        {
            this._notificationService = notificationService;
            this._mapper = mapper;
            this._userManager = userManager;
        }
		/// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<entity.NotificationEntity>> Get()
        {
            return await this._notificationService.GetAllAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetNotification")]
        [ProducesResponseType(typeof(model.NotificationViewModel), 200)]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var item = await this._notificationService.GetByIdAsync(id);
            if (item == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            var retVal = _mapper.Map<model.NotificationViewModel>(item);
            return new ObjectResult(retVal);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(model.NotificationCreateModel), 200)]
        public async Task<IActionResult> Create([FromBody] model.NotificationCreateModel model)
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

                var entityToInsert = this._mapper.Map<entity.NotificationEntity>(model);

                var affectedRow = await this._notificationService.InsertAsync(entityToInsert);

                if (affectedRow.HasValue && affectedRow.Value > 0)
                {
                    model.NotificationId = affectedRow.Value;
                    return CreatedAtRoute("GetNotification", new { id = model.NotificationId }, model);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Notification/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(model.NotificationUpdateModel), 200)]
        public async Task<IActionResult> Put([FromBody]model.NotificationUpdateModel model)
        {
            try
            {
                if (model == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                //var searchResult = await this._notificationService.GetByIdAsync(model.NotificationId);
                //if (searchResult == null)
                //{
                //    return StatusCode(StatusCodes.Status404NotFound);
                //}
                var entityToUpdate = this._mapper.Map<entity.NotificationEntity>(model);
                var result = await this._notificationService.UpdateAsync(entityToUpdate);
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
        [HttpDelete("{id}", Name = "DeleteNotification")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                var searchResult = await this._notificationService.GetByIdAsync(id);
                if (searchResult == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                var result = await this._notificationService.DeleteByIdAsync(id);
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
