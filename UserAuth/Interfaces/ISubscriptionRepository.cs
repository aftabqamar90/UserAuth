using UserAuth.Models.Requests.SubscriptionsRequest;
using UserAuth.Models.Responses.SubscriptionsResponse;

namespace UserAuth.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task CreateSubscriptionAsync(AddSubscriptionsRequest subscription);
        Task<GetSubscriptionResponse> GetSubscriptionAsync(long id);
        Task<IEnumerable<GetSubscriptionResponse>> GetSubscriptionsAsync(string? search);
        Task UpdateSubscriptionAsync(UpdateSubscriptionsRequest subscription);
        Task DeleteSubscriptionAsync(long id);
    }
}
