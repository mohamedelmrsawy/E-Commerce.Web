using AutoMapper;
using DomianLayer.Exceptions;
using DomianLayer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServiceAbstraction;
using Shared.DTO.IdentityDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthenticationService(UserManager<ApplicationUser> _userManager , IMapper _mapper) : IAuthenticationService
    {
        public async Task<bool> CheckEmailAsync(string email)
        {
            var user =await _userManager.FindByEmailAsync(email);
            return user is not null;
        }
        public async Task<UserDto> GetCurrentUserAsync(string Email)
        {
            var user =await _userManager.FindByEmailAsync(Email) ?? throw new UserNotFoundException(Email);
            return new UserDto() { DisplayName = user.DisplayName, Email = user.Email, Token = await CreateTokenAsync(user) };
        }
        public async Task<AddressDto> GetCurrentUserAddressAsync(string Email)
        {
            var user =await _userManager.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Email == Email) ?? throw new UserNotFoundException(Email);
            if(user.Address is not null) 
                return _mapper.Map<Address,AddressDto>(user.Address);
            else
                throw new AddressNotFoundException(Email);
        }
        public async Task<AddressDto> UpdateCurrentUserAddressAsync(AddressDto _addressDto, string Email)
        {
            var user = await _userManager.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Email == Email) ?? throw new UserNotFoundException(Email);
            if(user.Address is not null)
            {
                user.Address.FarstName = _addressDto.FirstName;
                user.Address.LastName = _addressDto.LastName;
                user.Address.City = _addressDto.City;
                user.Address.Country = _addressDto.Country;
                user.Address.Street = _addressDto.Street;
            }
            else
            {
                user.Address = _mapper.Map<AddressDto,Address>(_addressDto);
            }

            await _userManager.UpdateAsync(user);
            return _mapper.Map<AddressDto>(user.Address);
        }


        #region 01
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email) ?? throw new UserNotFoundException(loginDto.Email);
            var IsPassword = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (IsPassword)
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
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
                return new UserDto() { DisplayName = user.DisplayName, Email = user.Email, Token = "TOKEN-TODO" };
            else
            {
                var error = result.Errors.Select(e => e.Description).ToList();
                throw new BadRequestException(error);
            }
        }


        private async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var Claims = new List<Claim>()
            {
                new(ClaimTypes.Email, user.Email!),
                new(ClaimTypes.Name, user.UserName!),
                new(ClaimTypes.NameIdentifier, user.Id!)
            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
                Claims.Add(new Claim(ClaimTypes.Role, role));
            var secretKey = "MySecretKey";
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "MyIssuer",
                audience: "MyAudience",
                claims: Claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        } 
        #endregion
    }
}
