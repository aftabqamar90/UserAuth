namespace UserAuth.Models.Requests.UserRequest
{
    public class CreateUserRequest
    {
        public required string UserName { get; set; }
        public required string UserPassword { get; set; }
    }
}
