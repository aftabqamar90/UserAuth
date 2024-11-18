using Microsoft.EntityFrameworkCore;
using UserAuth.Models.Entities;
using UserAuth.Models.Responses.SubscriptionsResponse;

namespace UserAuth.Repositories
{
    public class SubscriptionRepository : Interfaces.ISubscriptionRepository
    {
        private readonly Data.Db _context;

        public SubscriptionRepository(Data.Db context)
        {
            _context = context;
        }

        public async Task CreateSubscriptionAsync(Models.Requests.SubscriptionsRequest.AddSubscriptionsRequest subscription)
        {
            if ((await _context.Subscriptions.FirstOrDefaultAsync(rr => rr.Name.ToLower() == subscription.Name.ToLower())) != null)
                throw new ArgumentException("Subscription already exists, Please try again.");

            _context.Subscriptions.Add(new Subscriptions() { Name = subscription.Name });
            await _context.SaveChangesAsync();
        }

        public async Task<Models.Responses.SubscriptionsResponse.GetSubscriptionResponse> GetSubscriptionAsync(long id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription == null)
                throw new ArgumentException("Subscription not found.");

            return new GetSubscriptionResponse() { Name = subscription.Name, Id = subscription.Id };
        }

        public async Task<IEnumerable<Models.Responses.SubscriptionsResponse.GetSubscriptionResponse>> GetSubscriptionsAsync(string? search)
        {
            return await _context.Subscriptions
                .Where(e => string.IsNullOrEmpty(search) || e.Name.ToLower().Contains(search.ToLower()))
                .Select(e => new Models.Responses.SubscriptionsResponse.GetSubscriptionResponse
                {
                    Name = e.Name,
                    Id = e.Id,
                }).ToListAsync();
        }

        public async Task UpdateSubscriptionAsync(Models.Requests.SubscriptionsRequest.UpdateSubscriptionsRequest subscription)
        {
            if ((await _context.Subscriptions.FirstOrDefaultAsync(rr => rr.Name.ToLower() == subscription.Name.ToLower() && rr.Id != subscription.Id)) != null)
                throw new ArgumentException("Subscription already exists, Please try again.");

            _context.Subscriptions.Update(new Subscriptions() { Name = subscription.Name, Id = subscription.Id });
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubscriptionAsync(long id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
                await _context.SaveChangesAsync();
            }
        }
    }
}
