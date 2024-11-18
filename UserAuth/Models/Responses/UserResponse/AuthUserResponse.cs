namespace UserAuth.Models.Responses.UserResponse
{
    public class AuthUserResponse
    {
        public long Id { get; set; }
        public required string UserName { get; set; }
        public string? Token { get; set; } = string.Empty;
    }
}
