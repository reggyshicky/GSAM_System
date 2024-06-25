namespace Application.UserManagement.Dto
{
    public class GetUserDto
    {
        public string FullName { get; set; }
        public string PfNumber { get; set; }
        public char ActiveFlag { get; set; }
        public DateTime RegisteredTime { get; set; }
        public string Email { get; set; }

        public string Role { get; set; }
    }
}
