using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.UserMngt
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string PfNumber { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
        public char ActiveFlag { get; set; } = 'N';
        public DateTime? RegisteredTime { get; set; }
        public string? ModifiedBy { get; set; }
        public char ModifiedFlag { get; set; } = 'N';
        public DateTime ModifiedTime { get; set; }
        public string? ActivatedBy { get; set; }
        public DateTime? ActivatedTime { get; set; }

        public string? DeactivatedBy { get; set; }

        public DateTime? DeactivatedTime { get; set; }
        public string? DeletedBy { get; set; }
        public char DeletedFlag { get; set; } = 'N';
        public DateTime? DeletedTime { get; set; }
    }
}