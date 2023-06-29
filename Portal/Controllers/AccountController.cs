using Domain;
using Domainservices.Interfaces.IRepositories;
using Domainservices.Interfaces.IServices;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using System;

namespace Portal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly IUserRepository _userRepository;
        private readonly IAccountService _accountService;

        public AccountController(UserManager<UserIdentity> userManager, SignInManager<UserIdentity> signInManager, IUserRepository userRepository, IAccountService accountService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(_accountService.CreateUserIdentityFromModel(model), model.Password);

                if (result.Succeeded)
                {
                    await _userRepository.AddUserAsync(_accountService.CreateUserFromModel(model));

                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UsernameOrEmail)
                            ?? await _userManager.FindByEmailAsync(model.UsernameOrEmail);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName,model.Password, false, lockoutOnFailure:false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }
            return View(model);
        }

     

    }
}
