namespace UserAuth.Models.Requests.UserSubscriptionsRequest
{
    public class AssignUserSubscriptionsRequest
    {
        public long UserId { get; set; }
        public long SubscriptionId { get; set; }
        public DateTime StartDate { get; set; }
    }
}