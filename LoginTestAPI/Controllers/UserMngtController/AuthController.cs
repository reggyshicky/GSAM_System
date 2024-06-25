using Application.Models;
using Application.UserManagement.Commands;
using Application.UserManagement.Dto;
using LoginTestAPI.Models.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginTestAPI.Controllers.UserMngtController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<APIResponse<Unit>>> Register([FromBody] RegisterRequest request)
        {
            return Ok(await _userService.RegisterAsync(request));
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<APIResponse<Unit>>> Login([FromBody] LoginRequest request)
        {
            return Ok(await _userService.LoginAsync(request));
        }

        //[Authorize]
        [HttpPost]
        [Route("ActivateUser")]
        public async Task<ActionResult<APIResponse<Unit>>> ActivateUser([FromBody] ActivateDto request)
        {
            return Ok(await _userService.ActivateUser(request));
        }

        [HttpGet]
        [Route("InActiveUsers")]
        public async Task<ActionResult<APIResponse<Unit>>> GetInActiveUsers()
        {
            return Ok(await _userService.GetInActiveUsers());
        }


        [HttpGet]
        [Route("AllUsers")]
        public async Task<ActionResult<APIResponse<Unit>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpPost("Logout")]
        [Authorize]
        public async Task<ActionResult<APIResponse<Unit>>> Logout()
        {
            return Ok(await _userService.Logout());
        }

        //[Authorize]
        [HttpPost]
        [Route("DeactivateUser")]
        public async Task<ActionResult<APIResponse<Unit>>> DeactivateUser([FromBody] ActivateDto request)
        {
            return Ok(await _userService.DeactivateUser(request));
        }

        // POST: /api/Auth/ChangePassword
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<ActionResult<APIResponse<Unit>>> ResetPassword([FromBody] ChangePasswordRequest request)
        {
            return Ok(await _userService.ResetPassword(request));
        }
    }
}









