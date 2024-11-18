using UserAuth.Interfaces;
using UserAuth.Models.Requests.UserSubscriptionsRequest;
using UserAuth.Models.Responses.UserSubscriptionsResponse;

namespace UserAuth.Services
{
    public class UserSubscriptionsService
    {
        private readonly IUserSubscriptionsRepository _userSubRepository;
        public UserSubscriptionsService(IUserSubscriptionsRepository _userSubRepository)
        {
            this._userSubRepository = _userSubRepository;
        }

        public async Task CreateSubscriptionAsync(Models.Requests.UserSubscriptionsRequest.AssignUserSubscriptionsRequest model)
        {
            await _userSubRepository.CreateUserSubscriptionAsync(model);
        }

        public async Task<List<GetUserSubscriptionResponse>> GetUserSubscriptionsAsync(long UserId, GetUserSubscriptionsRequest subscription)
        {
            return await _userSubRepository.GetUserSubscriptionsAsync(UserId, subscription);
        }
    }
}
