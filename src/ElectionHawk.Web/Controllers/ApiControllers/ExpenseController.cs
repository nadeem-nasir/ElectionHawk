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
    [Route("api/expense")]
    public class ExpenseController : BaseApiController
    {
        private readonly IExpenseService _expenseService;
        private readonly IMapper _mapper;
        private readonly UserManager<ElectionHawkIdentityUser> _userManager;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expenseService"></param>
        /// <param name="mapper"></param>
        /// <param name="userManager"></param>
        public ExpenseController(IExpenseService expenseService,
            IMapper mapper, UserManager<ElectionHawkIdentityUser> userManager) : base(userManager)
        {
            this._expenseService = expenseService;
            this._mapper = mapper;
            this._userManager = userManager;
        }
		/// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<entity.ExpenseEntity>> Get()
        {
            return await this._expenseService.GetAllAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetExpense")]
        [ProducesResponseType(typeof(model.ExpenseViewModel), 200)]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var item = await this._expenseService.GetByIdAsync(id);
            if (item == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            var retVal = _mapper.Map<model.ExpenseViewModel>(item);
            return new ObjectResult(retVal);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(model.ExpenseCreateModel), 200)]
        public async Task<IActionResult> Create([FromBody] model.ExpenseCreateModel model)
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

                var entityToInsert = this._mapper.Map<entity.ExpenseEntity>(model);

                var affectedRow = await this._expenseService.InsertAsync(entityToInsert);

                if (affectedRow.HasValue && affectedRow.Value > 0)
                {
                    model.ExpenseId = affectedRow.Value;
                    return CreatedAtRoute("GetExpense", new { id = model.ExpenseId }, model);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Expense/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(model.ExpenseUpdateModel), 200)]
        public async Task<IActionResult> Put([FromBody]model.ExpenseUpdateModel model)
        {
            try
            {
                if (model == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                //var searchResult = await this._expenseService.GetByIdAsync(model.ExpenseId);
                //if (searchResult == null)
                //{
                //    return StatusCode(StatusCodes.Status404NotFound);
                //}
                var entityToUpdate = this._mapper.Map<entity.ExpenseEntity>(model);
                var result = await this._expenseService.UpdateAsync(entityToUpdate);
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
        [HttpDelete("{id}", Name = "DeleteExpense")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                var searchResult = await this._expenseService.GetByIdAsync(id);
                if (searchResult == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                var result = await this._expenseService.DeleteByIdAsync(id);
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
