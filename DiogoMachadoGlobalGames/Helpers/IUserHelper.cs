using DiogoMachadoGlobalGames.Dados.Entidades;
using DiogoMachadoGlobalGames.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiogoMachadoGlobalGames.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<SignInResult> LoginInAsync(LoginViewModel model);


        Task LogoutAync();


    }
}
