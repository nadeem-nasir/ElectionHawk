using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionHawk.Web.Controllers.WebControllers
{

   
    public class HomeController : BaseWebController
    {
        private readonly UserManager<ElectionHawkIdentityUser> _userManager;
        private readonly IHostingEnvironment _env;
        public HomeController(
       UserManager<ElectionHawkIdentityUser> userManager,
       IHostingEnvironment env


       )
        {
            _userManager = userManager;

            _env = env;

        }

       
        public async Task<IActionResult> Index()
        {
            if (ConfirmEmailRequest())
            {
                await ConfirmEmail();
            }
            return View();
        }

        private bool ConfirmEmailRequest()
        {
            return Request.Query.ContainsKey("emailConfirmCode") && Request.Query.ContainsKey("userId");
        }

        private async Task ConfirmEmail()
        {
            var userId = Request.Query["userId"].ToString();
            var code = Request.Query["emailConfirmCode"].ToString();
            code = code.Replace(" ", "+");

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null && !user.EmailConfirmed)
            {
                var valid = await _userManager.ConfirmEmailAsync(user, code);
                if (valid.Succeeded)
                {
                    ViewBag.emailConfirmed = true;
                }
            }
        }
        
        public async Task<IActionResult> About()
        {
            if (ConfirmEmailRequest())
            {
                await ConfirmEmail();
            }
            return View();
            
        }
    }
}
