using JWT_Demo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JWT_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// to get the role of user - if its Admin/Std, 
        /// authenticate the user, from token we can fetch claims (UserModel) which contains roles along with other user info.
        [HttpGet("UserInfo")]
        [Authorize]
        public IActionResult GetAdmins()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser?.DisplayName}, you are an {currentUser?.Role}");
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext?.User.Identity as ClaimsIdentity;
            if (identity != null) 
            {
                var userClaims = identity?.Claims;

                return new UserModel
                {
                    Username = userClaims?.FirstOrDefault(x => x?.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClaims?.FirstOrDefault(x => x?.Type == ClaimTypes.Email)?.Value,
                    Role = userClaims?.FirstOrDefault(x => x?.Type == ClaimTypes.Role)?.Value,
                    DisplayName = userClaims?.FirstOrDefault(x => x?.Type == ClaimTypes.GivenName)?.Value,
                };
            }
            return null;
        }
    }
}
