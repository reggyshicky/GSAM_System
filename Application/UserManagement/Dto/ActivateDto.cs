using System.ComponentModel.DataAnnotations;

namespace Application.UserManagement.Dto
{
    public class ActivateDto
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
