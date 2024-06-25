namespace Application.Common
{
    public interface ICurrentUser
    {
        string? GetCurrentUserId();
        string? GetCurrentUserName();
    }
}
