using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace DEKODE.AttendMe.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        // You should only access the User property (and others such as HttpContext) from within actions of your controller.
        // The controller is constructed before authentication and authorization have been performed, hence the properties are null.
        // https://stackoverflow.com/questions/54745142/why-is-my-basecontroller-user-value-null-when-the-area-controller-loads

        public string UserName
        {
            get
            {
                if (User != null)
                    return User.FindFirst(ClaimTypes.Name).Value;
                return null;
            }
        }

        public int? OrganisationId
        {
            get
            {
                if (User != null)
                    return Convert.ToInt32(User.FindFirst(ClaimTypes.Sid).Value);

                return null;
            }
        }

        //public BaseController(IHttpContextAccessor accessor)
        //{
        //    //HttpContext.GetTokenAsync("access_token");
        //    //var identity = HttpContext.User.Identity as ClaimsIdentity;
        //    //var sid = identity.FindFirst("sid");

        //    //if (User != null)
        //    //{
        //    //    UserName = User.FindFirst(ClaimTypes.Name).Value;
        //    //    OrganisationId = Convert.ToInt32(User.FindFirst(ClaimTypes.Sid).Value);
        //    //}

        //    if (accessor.HttpContext.User.Claims.Count() > 0)
        //    {
        //        UserName = accessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        //        OrganisationId = Convert.ToInt32(accessor.HttpContext.User.FindFirst(ClaimTypes.Sid).Value);
        //    }
        //}
    }
}