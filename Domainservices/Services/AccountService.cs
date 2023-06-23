using Domain;
using Domainservices.Interfaces.IServices;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainservices.Services
{
    public class AccountService : IAccountService
    {


        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;


        public AccountService(UserManager<UserIdentity> userManager, SignInManager<UserIdentity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public Task<bool> LoginAsync(string usernameOrEmail, string password)
        {

            throw new NotImplementedException();
        }

        public Task<bool> RegisterAsync(string username, string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
