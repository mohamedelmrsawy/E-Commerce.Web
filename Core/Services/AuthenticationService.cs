using DomianLayer.Exceptions;
using DomianLayer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using ServiceAbstraction;
using Shared.DTO.IdentityDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthenticationService(UserManager<ApplicationUser> _userManager) : IAuthenticationService
    {
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var user =await _userManager.FindByEmailAsync(loginDto.Email) ?? throw new UserNotFoundException(loginDto.Email);
            var IsPassword = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if(IsPassword)
            {
                return new UserDto
                {
                    Email = user.Email,
                    DisplayName = user.DisplayName,
                    Token = "TOKEN - TODO"
                };
            }
            else
            {
                throw new UserNotFoundException(loginDto.Email);
            }
        }


        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            var user = new ApplicationUser()
            {
                Email = registerDto.Email,
                DisplayName = registerDto.DisplayName,
                PhoneNumber = registerDto.PhoneNumber,
                UserName = registerDto.UserName
            };
            var  result =await _userManager.CreateAsync(user,registerDto.Password);
            if(result.Succeeded)
                return new UserDto() { DisplayName = user.DisplayName, Email = user.Email , Token = "TOKEN-TODO" };
            else
            {
                var error = result.Errors.Select(e => e.Description).ToList();
                throw new BadRequestException(error);
            }
        }
    }
}
