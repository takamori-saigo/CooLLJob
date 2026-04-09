using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CoolJob.Controllers
{
    public class LanguageController : Controller
    {
        [HttpPost]
        public IActionResult Set(string culture, string returnUrl)
        {
            if (culture != "ru" && culture != "en") culture = "ru";
            
            Response.Cookies.Append(
                "Culture", 
                culture, 
                new CookieOptions { MaxAge = TimeSpan.FromDays(365) }
            );
            
            return LocalRedirect(returnUrl);
        }
    }
}