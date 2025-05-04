using Shared.DTO.IdentityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IAuthenticationService
    {
        Task<UserDto> LoginAsync(LoginDto loginDto);
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<bool> CheckEmailAsync(string email);
        Task<AddressDto> GetCurrentUserAddressAsync(string Email);
        Task<AddressDto> UpdateCurrentUserAddressAsync(AddressDto addressDto , string Email);
        Task<UserDto> GetCurrentUserAsync(string Email);
    }
}
