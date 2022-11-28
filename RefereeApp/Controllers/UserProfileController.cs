using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RefereeApp.Models;
//using System.Web.Http;

namespace RefereeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };
        }
        /*
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("ForAdmin")]
        public string GetForAdmin()
        {
            return "Web method for Admin";
        }

        [HttpGet]
        [Authorize(Roles = "Referee")]
        [Route("ForReferee")]
        public string GetReferee()
        {
            return "Web method for Referee";
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Referee")]
        [Route("ForAdminOrReferee")]
        public string GetForAdminOrReferee()
        {
            return "Web method for Admin or Referee";
        }
        */
        [HttpPost]
        [Authorize]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(string password)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);
            await _userManager.UpdateAsync(user);
            return Ok();
        }

        [HttpPost]
        [Authorize]
        [Route("ChangeEmail")]
        public async Task<IActionResult> ChangeEmail(string email)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);

            user.Email = email;
            await _userManager.UpdateAsync(user);
            return Ok();
        }


    }
}
