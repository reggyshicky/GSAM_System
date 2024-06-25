using Application.Common;
using System.Security.Claims;

namespace LoginTestAPI.Utils
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string? GetCurrentUserId()
        {

            return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string? GetCurrentUserName()
        {
            var results = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
            return results;
        }
    }
}
