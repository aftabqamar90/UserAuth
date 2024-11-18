using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserAuth.Models.Requests.SubscriptionsRequest;
using UserAuth.Models.Responses.SubscriptionsResponse;


namespace UserAuth.Controllers
{
    [ApiController]
    [Route("Subscriptions")]
    [Authorize]
    public class SubscriptionsController : ControllerBase
    {
        private readonly Services.SubscriptionsService _subcriptionServices;
        public SubscriptionsController(Services.SubscriptionsService _subcriptionServices)
        {
            this._subcriptionServices = _subcriptionServices;
        }

        [HttpGet]
        public async Task<IEnumerable<GetSubscriptionResponse>> Get(string? search)
        {
            return await _subcriptionServices.GetSubscriptionsAsync(search);
        }

        [HttpGet("{id}")]
        public async Task<GetSubscriptionResponse> Get(int id)
        {
            return await _subcriptionServices.GetSubscriptionAsync(id);
        }

        [HttpPost]
        public async Task Post(AddSubscriptionsRequest model)
        {
            await _subcriptionServices.CreateSubscriptionAsync(model);
        }

        [HttpPut]
        public async void Put(UpdateSubscriptionsRequest model)
        {
            await _subcriptionServices.UpdateSubscriptionAsync(model);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _subcriptionServices.DeleteSubscriptionAsync(id);
        }
    }
}
