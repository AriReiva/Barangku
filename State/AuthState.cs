using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barangku.Model.DTO;
using Barangku.Model.ViewModel;
using Barangku.Model.Entities;


namespace Barangku.State
{
    public class AuthState
    {
        public UserDto? CurrentUser { get; set; }
        public string? Token { get; set; }

        public void SetAuthState(UserDto user, string token)
        {
            CurrentUser = user;
            Token = token;
        }

        public void ClearAuthState()
        {
            CurrentUser = null;
            Token = null;
        }

        public bool IsAuthenticated()
        {
            return CurrentUser != null && !string.IsNullOrEmpty(Token);
        }
    }
}