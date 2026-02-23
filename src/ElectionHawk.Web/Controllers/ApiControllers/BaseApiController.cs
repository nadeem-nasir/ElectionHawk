using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ElectionHawk.Web.Controllers.ApiControllers
{
    public class BaseApiController : Controller
    {
        private readonly UserManager<ElectionHawkIdentityUser> _userManager;

        public BaseApiController(UserManager<ElectionHawkIdentityUser> userManager)
        {
            this._userManager = userManager;
        }

        [NonAction]
        public Task<ElectionHawkIdentityUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}

