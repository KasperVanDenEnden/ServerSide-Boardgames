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
        public UserIdentity CreateUserIdentityFromModel(dynamic model)
        {
            return new UserIdentity { UserName = model.Username, Email = model.Email };
        }

        public User CreateUserFromModel(dynamic model)
        {
            DateTime dateTime = new(model.DateOfBirth.Year, model.DateOfBirth.Month, model.DateOfBirth.Day);
            return new User { UserName = model.Username, Email = model.Email, DateOfBirth = dateTime };
        }

    }
}
