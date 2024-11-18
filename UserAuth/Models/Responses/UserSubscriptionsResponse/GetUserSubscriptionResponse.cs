using System.ComponentModel.DataAnnotations;

namespace UserAuth.Models.Responses.UserSubscriptionsResponse
{
    public class GetUserSubscriptionResponse
    {
        [Key]
        public long subscription_id { get; set; }
        public string? subscription_name { get; set; }
        public DateTime start_date { get; set; }
    }
}
