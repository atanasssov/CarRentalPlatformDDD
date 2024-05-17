using Microsoft.AspNetCore.Mvc;

using CarRentalPlatform.Application.Features.Identity.Commands.LoginUser;
using CarRentalPlatform.Application.Features.Identity.Commands.CreateUser;

namespace CarRentalPlatform.Web.Features
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ApiController
    {
        
        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(CreateUserCommand command)
        {
            return await this.Send(command);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(LoginUserCommand command)
        {
            return await this.Send(command);
        }
    }
}
