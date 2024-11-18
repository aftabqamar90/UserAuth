using UserAuth.Interfaces;

namespace UserAuth.Services
{
    public class SubscriptionsService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public SubscriptionsService(ISubscriptionRepository _subscriptionRepository)
        {
            this._subscriptionRepository = _subscriptionRepository;
        }

        public async Task CreateSubscriptionAsync(Models.Requests.SubscriptionsRequest.AddSubscriptionsRequest subscription)
        {
            await _subscriptionRepository.CreateSubscriptionAsync(subscription);
        }

        public async Task<Models.Responses.SubscriptionsResponse.GetSubscriptionResponse> GetSubscriptionAsync(long id)
        {
            return await _subscriptionRepository.GetSubscriptionAsync(id);
        }

        public async Task<IEnumerable<Models.Responses.SubscriptionsResponse.GetSubscriptionResponse>> GetSubscriptionsAsync(string? search)
        {
            return await _subscriptionRepository.GetSubscriptionsAsync(search);
        }

        public async Task UpdateSubscriptionAsync(Models.Requests.SubscriptionsRequest.UpdateSubscriptionsRequest subscription)
        {
            await _subscriptionRepository.UpdateSubscriptionAsync(subscription);
        }

        public async Task DeleteSubscriptionAsync(long id)
        {
            await _subscriptionRepository.DeleteSubscriptionAsync(id);
        }
    }
}
