using Application.Models;
using LoginTestAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoginTestAPI.Controllers.UserMngtController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        //[Authorize(Roles = "admin")]
        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _roleService.GetRolesAsync());
        }

        //[Authorize(Roles = "admin,user")]
        [HttpGet("GetUserRole")]
        public async Task<IActionResult> GetUserRole(string userEmail)
        {
            var userClaims = await _roleService.GetUserRolesAsync(userEmail);
            return Ok(userClaims);
        }

        //[Authorize(Roles = "admin")]
        [HttpPost("AddRoles")]
        public async Task<ActionResult> AddRole(string role)
        {
            return Ok(await _roleService.AddRolesAsync(role));
        }

        //[Authorize(Roles = "admin")]
        [HttpPost("AddUserRoles")]
        public async Task<ActionResult> AddUserRole([FromBody] AddUserModel addUser)
        {
            return Ok(await _roleService.AddUserRoleAsync(addUser.UserEmail, addUser.Role));
        }
    }
}
