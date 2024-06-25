using Application.Common;
using Application.EmailService;
using Application.Models;
using Application.UserManagement.Dto;
using AutoMapper;
using Domain.Entities.UserMngt;
using Domain.IRepositories;
using LoginTestAPI.Models.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.UserManagement.Commands
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenRepository _tokenRepo;
        private readonly ICurrentUser _currentUser;
        private readonly IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ITokenRepository tokenRepo,
            ICurrentUser currentUser, IMapper mapper, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenRepo = tokenRepo;
            _currentUser = currentUser;
            _mapper = mapper;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public async Task<APIResponse<Unit>> RegisterAsync(RegisterRequest request)
        {
            var userExist = await _userManager.FindByNameAsync(request.Email);
            if (userExist != null)
            {
                return new APIResponse<Unit>
                {
                    Message = "User already exists",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Email,
                FullName = request.FullName,
                PfNumber = request.PfNumber,
                Gender = request.Gender,
                RegisteredTime = DateTime.Now,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return new APIResponse<Unit>
                {
                    Message = "Error occurred while creating User",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
            if (await _roleManager.RoleExistsAsync("User"))
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return new APIResponse<Unit>
            {
                Message = "User Created Successfully!",
                StatusCode = HttpStatusCode.Created,
            };
        }

        public async Task<APIResponse<object>> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                if (user.ActiveFlag == 'Y')
                {
                    var checkPasswordResult = await _userManager.CheckPasswordAsync(user, request.Password);
                    if (checkPasswordResult)
                    {
                        //Get roles for the user
                        var roles = await _userManager.GetRolesAsync(user);
                        var rolesList = roles?.ToList();
                        if (rolesList != null)
                        {
                            rolesList.Remove("User");
                        }
                        if (rolesList == null || rolesList.Count == 0)
                        {
                            return new APIResponse<object>
                            {
                                Message = "User does not have any roles",
                                StatusCode = HttpStatusCode.BadRequest
                            };
                        }
                        var jwtToken = _tokenRepo.CreateJwtToken(user, rolesList);
                        return new APIResponse<object>
                        {
                            Message = "User loggedIn Succesfully",
                            StatusCode = HttpStatusCode.OK,
                            Result = new
                            {
                                Token = jwtToken,
                                ExpiresIn = 900,
                                Roles = rolesList,
                                user.Email
                            }
                        };
                    }
                }
                else
                {
                    return new APIResponse<object>
                    {
                        Message = "Please Contact the Adminstrator!",
                        StatusCode = HttpStatusCode.BadRequest,
                    };
                }

            }
            return new APIResponse<object>
            {
                Message = "Invalid Email or Password",
                StatusCode = HttpStatusCode.BadRequest,
            };
        }

        public async Task<APIResponse<object>> ActivateUser(ActivateDto dto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(dto.Email);
                if (user != null)
                {
                    if (user.ActiveFlag == 'N')
                    {
                        user.ActiveFlag = 'Y';
                        user.ActivatedBy = _currentUser.GetCurrentUserName();
                        user.ActivatedTime = DateTime.Now;
                        var result = await _userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            await _emailSender.SendEmailAsync(dto.Email, "Account Activation", $"Account for user {user.UserName} activated succesfully");
                            return new APIResponse<object>
                            {
                                Message = "User activated successfully!",
                                StatusCode = HttpStatusCode.OK,
                            };
                        }
                        else
                        {
                            return new APIResponse<object>
                            {
                                Message = "Failed to update user status.",
                                StatusCode = HttpStatusCode.InternalServerError,
                            };
                        }

                    }
                    else if (user.ActiveFlag == 'Y')
                    {
                        return new APIResponse<object>
                        {
                            Message = "User is already activated!",
                            StatusCode = HttpStatusCode.BadRequest,
                        };
                    }
                }
                return new APIResponse<object>
                {
                    Message = "User not found!",
                    StatusCode = HttpStatusCode.BadRequest,
                };
            }
            catch (Exception ex)
            {
                return new APIResponse<object>
                {
                    Message = $"Error occurred while activating the user with email {dto.Email}",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }

        }

        public async Task<APIResponse<object>> DeactivateUser(ActivateDto dto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(dto.Email);
                if (user != null)
                {
                    if (user.ActiveFlag == 'Y')
                    {
                        user.ActiveFlag = 'N';
                        user.DeactivatedBy = _currentUser.GetCurrentUserName();
                        user.DeactivatedTime = DateTime.Now;
                        var result = await _userManager.UpdateAsync(user);
                        return new APIResponse<object>
                        {
                            Message = "User Deactivated successfully!",
                            StatusCode = HttpStatusCode.OK,
                        };
                    }
                    else if (user.ActiveFlag == 'Y')
                    {
                        return new APIResponse<object>
                        {
                            Message = "User is already deactivated!",
                            StatusCode = HttpStatusCode.BadRequest,
                        };
                    }
                }
                return new APIResponse<object>
                {
                    Message = "User not found!",
                    StatusCode = HttpStatusCode.BadRequest,
                };
            }
            catch (Exception ex)
            {
                return new APIResponse<object>
                {
                    Message = $"Error occurred while deactivating the user with email {dto.Email}",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }

        }

        public async Task<APIResponse<List<GetUserDto>>> GetInActiveUsers()
        {
            try
            {
                var results = await _userManager.Users.Where(x => x.ActiveFlag == 'N' && x.DeletedFlag == 'N').ToListAsync();
                return new APIResponse<List<GetUserDto>>
                {
                    Message = $"Inactive Users retrieved succesfully",
                    StatusCode = HttpStatusCode.OK,
                    Result = _mapper.Map<List<GetUserDto>>(results)
                };
            }
            catch (Exception ex)
            {
                return new APIResponse<List<GetUserDto>>
                {
                    Message = $"Error occurred while retrieving inactive users",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }

        public async Task<APIResponse<List<GetUserDto>>> GetAllUsers()
        {
            try
            {
                var results = await _userManager.Users.Where(x => x.DeletedFlag == 'N').ToListAsync();
                return new APIResponse<List<GetUserDto>>
                {
                    Message = $"All users retrieved succesfully",
                    StatusCode = HttpStatusCode.OK,
                    Result = _mapper.Map<List<GetUserDto>>(results),
                };
            }
            catch (Exception ex)
            {
                return new APIResponse<List<GetUserDto>>
                {
                    Message = $"Error occurred while retrieving inactive users",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }

        public async Task<APIResponse<Unit>> Logout()
        {
            await _signInManager.SignOutAsync();
            return new APIResponse<Unit>
            {
                Message = "Logged out successfully",
                StatusCode = HttpStatusCode.OK,
            };
        }


        public async Task<APIResponse<Unit>> ResetPassword(ChangePasswordRequest changePasswordRequest)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(changePasswordRequest.Email);

                if (user == null)
                {
                    return new APIResponse<Unit>
                    {
                        Message = "User not Found",
                        StatusCode = HttpStatusCode.BadRequest,
                    };
                }

                var result = await _userManager.ChangePasswordAsync(user, changePasswordRequest.OldPassword, changePasswordRequest.NewPassword);

                if (result.Succeeded)
                {
                    return new APIResponse<Unit>
                    {
                        Message = "Password Changed Successfully",
                        StatusCode = HttpStatusCode.OK,
                    };
                }

                return new APIResponse<Unit>
                {
                    Message = "Username or Password incorrect",
                    StatusCode = HttpStatusCode.BadRequest,
                };
            }
            catch (Exception ex)
            {
                return new APIResponse<Unit>
                {
                    Message = "Error occurred while changing password, Please try again later!",
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }
    }
}


