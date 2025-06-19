using Microsoft.AspNetCore.Mvc;
using MediatR;
using Pizza.Application.features.auth;
namespace Pizza.API.Controllers
{
    public class RegisterController(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;
        [HttpPost("register")]
        public async Task<ActionResult<string>> Registration([FromBody] RegistrationCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}
