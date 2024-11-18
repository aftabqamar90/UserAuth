using Microsoft.EntityFrameworkCore;
using UserAuth.Models.Requests.UserSubscriptionsRequest;
using UserAuth.Models.Responses.UserSubscriptionsResponse;
using UserAuth.Extension;

namespace UserAuth.Repositories
{
    public class UserSubscriptionsRepository : Interfaces.IUserSubscriptionsRepository
    {
        private readonly Data.Db _context;
        public UserSubscriptionsRepository(Data.Db context)
        {
            _context = context;
        }

        public async Task CreateUserSubscriptionAsync(AssignUserSubscriptionsRequest subscription)
        {
            var existingSubscription = await _context.UserSubscriptions.
                AnyAsync(us => us.UserId == subscription.UserId && us.SubscriptionId == subscription.SubscriptionId);

            if (existingSubscription)
            {
                throw new InvalidOperationException("User already has this subscription");
            }

            await _context.UserSubscriptions.AddAsync(new Models.Entities.UserSubscriptions()
            {
                StartDate = subscription.StartDate,
                SubscriptionId = subscription.SubscriptionId,
                UserId = subscription.UserId,
            });
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetUserSubscriptionResponse>> GetUserSubscriptionsAsync(long UserId, GetUserSubscriptionsRequest subscription)
        {
            var results = await _context.GetUserSubscriptionResponse
         .FromSqlInterpolated($@"
            SELECT * FROM get_user_subscriptions(
                {UserId}, 
                {subscription.PageSize}, 
                {subscription.PageNumber}, 
                {subscription.Search}
            )")
         .ToListAsync();

            return results;
        }
    }
}
