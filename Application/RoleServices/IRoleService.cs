using Application.Models;
using Domain.Entities.Auth;
using MediatR;

namespace LoginTestAPI.Services
{
    public interface IRoleService
    {
        Task<APIResponse<List<RoleModel>>> GetRolesAsync();
        Task<List<string>> GetUserRolesAsync(string emailId);
        Task<APIResponse<Unit>> AddRolesAsync(string role);
        Task<APIResponse<Unit>> AddUserRoleAsync(string userEmail, string role);
    }
}
