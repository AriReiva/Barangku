using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barangku.Model.DTO;
using Barangku.Model.ViewModel;

namespace Barangku.Service.Interface
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAsync(RegisterDto model);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task<(string token, UserDto user)> LoginAsync(LoginDto model);
    }
}