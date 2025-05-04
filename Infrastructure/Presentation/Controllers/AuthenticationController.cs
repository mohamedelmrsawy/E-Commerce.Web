using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DTO.IdentityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthenticationController(IServiceManager _serviceManager) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user =await _serviceManager.authenticationService.LoginAsync(loginDto);
            return Ok(user);
        }

        [HttpPost("Register")]

        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var user =await _serviceManager.authenticationService.RegisterAsync(registerDto);
            return Ok(user);
        }
    }
}
