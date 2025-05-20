using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SUFEEASP.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext context)
        {
            var username = HttpContext.Session.GetString("Username");
            if (!string.IsNullOrEmpty(username))
            {
                ViewData["WelcomeMessage"] = $"Hi, {username}!";
            }
            base.OnActionExecuting(context);
        }
    }
}
