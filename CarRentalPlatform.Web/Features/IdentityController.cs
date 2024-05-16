﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using CarRentalPlatform.Application.Contracts;
using CarRentalPlatform.Application.Features.Identity;
namespace CarRentalPlatform.Web.Features
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentity identity;

        public IdentityController(IIdentity identity) => this.identity = identity;

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(UserInputModel model)
        {
            var result = await this.identity.Register(model);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(UserInputModel model)
        {
            var result = await this.identity.Login(model);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return result.Data;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return this.Ok(this.User.Identity.Name);
        }
    }
}
