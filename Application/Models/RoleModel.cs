using Microsoft.Identity.Client;

namespace Domain.Entities.Auth
{
    public class RoleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
