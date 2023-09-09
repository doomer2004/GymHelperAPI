using GymAPI.BLL.Services.Interfaces;
using GymAPI.Common.DTO;
using GymHelper.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GymHelperAPI.Controllers;
[Route("/")]
[ApiController]
public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService service)
    {
        _subscriptionService = service;
    }

    [HttpPost("Subscriptions/newSubscriptions")]
    public async Task<IActionResult> CreateSubscription(SubscriptionDTO subscription)
    {
        try
        {
            var result = await _subscriptionService.AddSubscription(subscription);
            return CreatedAtAction(nameof(GetSubscriptionByType),
                new {name = result.Type}, result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("Subscriptions")]
    public IActionResult GetAllSubscriptions()
    {
        return Ok(_subscriptionService.GetAllSubscription());
    }
    
    [HttpGet("subscription/{type}")]
    public async Task<IActionResult> GetSubscriptionByType(string type)
    {
        return Ok(await _subscriptionService.GetSubscriptionByType(type));
    }

    [HttpPut("subscription/{type}")]
    public async Task<IActionResult> UpdateSubscription(string type,
        [FromBody] UpdateSubscriptionDTO subscription)
    {
        try
        {
            return Ok(await _subscriptionService.UpdateSubscription(type, subscription));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(type);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("subscription/{type}")]
    public async Task<IActionResult> DeleteSubscription(string type)
    {
        return Ok(await _subscriptionService.DeleteSubscription(type));
    }
    
}