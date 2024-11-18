namespace UserAuth.Models.Requests.UserRequest
{
    public class AuthUserRequest
    {
        public required string UserName { get; set; }
        public required string UserPassword { get; set; }
    }
}
