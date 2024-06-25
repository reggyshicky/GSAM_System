using Application.Models;
using Domain.Entities.Auth;
using Domain.Entities.UserMngt;
using LoginTestAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<APIResponse<List<RoleModel>>> GetRolesAsync()
        {
            var roleList = _roleManager.Roles.Select(x =>
            new RoleModel { Id = Guid.Parse(x.Id), Name = x.Name }).ToList();
            return new APIResponse<List<RoleModel>>
            {
                Message = "Roles retrieved  successfully!",
                StatusCode = HttpStatusCode.OK,
                Result = roleList
            };

        }

        public async Task<List<string>> GetUserRolesAsync(string emailId)
        {
            var user = await _userManager.FindByEmailAsync(emailId);
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.ToList();
        }
        public async Task<APIResponse<Unit>> AddRolesAsync(string role)
        {
            try
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));

                    return new APIResponse<Unit>
                    {
                        Message = "Role created successfully!",
                        StatusCode = HttpStatusCode.Created,
                    };
                }
                return new APIResponse<Unit>
                {
                    Message = "Role Exists",
                    StatusCode = HttpStatusCode.BadRequest,
                };
            }
            catch (Exception ex)
            {
                return new APIResponse<Unit>
                {
                    Message = "Error occurred while adding a role",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }

        }
        public async Task<APIResponse<Unit>> AddUserRoleAsync(string userEmail, string role)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return new APIResponse<Unit>
                {
                    Message = "User not found.",
                    StatusCode = HttpStatusCode.BadRequest,
                };
            }

            if (user.ActiveFlag == 'Y')
            {
                var currentRole = await _userManager.GetRolesAsync(user);

                // Check if the user already has the specified role
                if (currentRole.Contains(role))
                {
                    return new APIResponse<Unit>
                    {
                        Message = $"User already has the role '{role}'.",
                        StatusCode = HttpStatusCode.BadRequest,
                    };
                }

                // Remove the user's current roles
                if (currentRole.Any())
                {
                    var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRole);
                    if (!removeResult.Succeeded)
                    {
                        return new APIResponse<Unit>
                        {
                            Message = "Failed to remove user's existing role.",
                            StatusCode = HttpStatusCode.InternalServerError
                        };
                    }
                }

                // Ensure the role exists, create if it does not
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole(role));
                    if (!roleResult.Succeeded)
                    {
                        return new APIResponse<Unit>
                        {
                            Message = "Failed to create the new role.",
                            StatusCode = HttpStatusCode.InternalServerError
                        };
                    }
                }

                // Add the user to the new role
                var addResult = await _userManager.AddToRoleAsync(user, role);
                if (!addResult.Succeeded)
                {
                    return new APIResponse<Unit>
                    {
                        Message = "Failed to add the user to the new role.",
                        StatusCode = HttpStatusCode.InternalServerError
                    };
                }
                user.Role = role;
                await _userManager.UpdateAsync(user);
                return new APIResponse<Unit>
                {
                    Message = "User's role successfully updated.",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
            else
            {
                return new APIResponse<Unit>
                {
                    Message = "User is InActive, Activate User to Proceed.",
                    StatusCode = HttpStatusCode.BadRequest,
                };
            }
        }

        public async Task<List<string>> ExistsRolesAsync(string[] roles)
        {
            var roleList = new List<string>();
            foreach (var role in roles)
            {
                var roleExist = await _roleManager.RoleExistsAsync(role);
                if (roleExist)
                {
                    roleList.Add(role);
                }
            }
            return roleList;
        }

        public async Task<bool> DeleteRoleAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return false;
            }

            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }
    }

}

