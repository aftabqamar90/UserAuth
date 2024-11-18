using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserAuth.Models.Requests.SubscriptionsRequest;
using UserAuth.Models.Requests.UserSubscriptionsRequest;
using UserAuth.Models.Responses.UserSubscriptionsResponse;


namespace UserAuth.Controllers
{

    [ApiController]
    [Route("UserSubscriptions")]
    public class UserSubscriptionsController : ControllerBase
    {
        private readonly Services.UserSubscriptionsService _userSubService;
        public UserSubscriptionsController(Services.UserSubscriptionsService userSubService)
        {
            _userSubService = userSubService;
        }

        [HttpPost]
        public async Task Post(AssignUserSubscriptionsRequest model)
        {
            await _userSubService.CreateSubscriptionAsync(model);
        }

        [Authorize]
        [HttpPost]
        [Route("MySubscription")]
        public async Task<List<GetUserSubscriptionResponse>> MySubscription(GetUserSubscriptionsRequest model)
        {
            var userId = long.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
                                  throw new Exception("User not found or claim missing"));
            return await _userSubService.GetUserSubscriptionsAsync(userId, model);
        }
    }
}
