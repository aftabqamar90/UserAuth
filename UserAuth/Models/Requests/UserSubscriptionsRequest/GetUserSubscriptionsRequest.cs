namespace UserAuth.Models.Requests.UserSubscriptionsRequest
{
    public class GetUserSubscriptionsRequest
    {
        public required int PageSize { get; set; } = 10;
        public required int PageNumber { get; set; } = 1;
        public string? Search { get; set; } = "";
    }
}
