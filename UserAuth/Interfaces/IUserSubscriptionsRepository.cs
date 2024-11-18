using UserAuth.Models.Requests.UserSubscriptionsRequest;

namespace UserAuth.Interfaces
{
    public interface IUserSubscriptionsRepository
    {
        Task CreateUserSubscriptionAsync(AssignUserSubscriptionsRequest subscription);
        Task<List<Models.Responses.UserSubscriptionsResponse.GetUserSubscriptionResponse>> GetUserSubscriptionsAsync(long UserId, GetUserSubscriptionsRequest subscription);
    }
}