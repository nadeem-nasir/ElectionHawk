using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionHawk.Web.Helpers
{
    public  static class RenderHelpers
    {
        public static IActionResult Render(this Controller ctrl, ExternalLoginStatus status)
        {
            return ctrl.RedirectToAction("Index", "Home", new { externalLoginStatus = (int)status });
        }
    }
}
