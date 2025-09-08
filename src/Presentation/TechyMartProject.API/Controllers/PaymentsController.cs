using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using TechyMartProject.Application.DTOs.PaymentDTO;
using TechyMartProject.Application.Services.Services;

namespace TechyMartProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IConfiguration _configuration;

        public PaymentsController(IPaymentService paymentService, IConfiguration configuration)
        {
            _paymentService = paymentService;
            _configuration = configuration;
        }

        [HttpPost("create-intent")]
        public async Task<IActionResult> CreatePaymentIntent([FromBody] CreatePaymentDto dto)
        {
            var payment = await _paymentService.CreatePayment(dto);
            return Ok(payment);
        }

        [HttpPost("webhook")]
        public async Task<IActionResult> Webhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var secret = _configuration["Stripe:WebhookSecret"];

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], secret);

                if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                {
                    var intent = stripeEvent.Data.Object as PaymentIntent;
                    await _paymentService.UpdatePaymentStatusAsync(intent.Id, "succeeded");
                }
                else if (stripeEvent.Type == Events.PaymentIntentPaymentFailed)
                {
                    var intent = stripeEvent.Data.Object as PaymentIntent;
                    await _paymentService.UpdatePaymentStatusAsync(intent.Id, "failed");
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("status/{intentId}")]
        public async Task<IActionResult> GetPaymentStatus(string intentId)
        {
            var payment = await _paymentService.GetPaymentByIntentId(intentId);
            return payment != null ? Ok(payment) : NotFound();
        }
    }
}
