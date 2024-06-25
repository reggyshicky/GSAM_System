using Domain.Entities.UserMngt;

namespace Domain.IRepositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(ApplicationUser user, List<String> roles);
    }
}
