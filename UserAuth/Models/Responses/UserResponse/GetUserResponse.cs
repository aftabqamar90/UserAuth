namespace UserAuth.Models.Responses.UserResponse
{
    public class GetUserResponse
    {
        public long Id { get; set; }
        public required string UserName { get; set; }
    }
}
