using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using SchoolProject.Helpers;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    [Authorize]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        #region Register

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.Email.Split('@')[0],
                    Email = model.Email,
                    IsAgree = model.IsAgree,
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                return RedirectToAction(nameof(Login));
                foreach(var error  in result.Errors)
                   ModelState.AddModelError(String.Empty, error.Description);
            }
            return View(model);
        }

        #endregion


        #region Login

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    var password = await UserManager.CheckPasswordAsync(user, model.Password);
                    if (password)
                    {
                        var result = await SignInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }

            }
                return View(model);
        }

        #endregion
        #region Signout

        public async new Task<IActionResult> SignOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        #endregion

        #region Forget Password
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await UserManager.GeneratePasswordResetTokenAsync(user);
                    var resetPasswordLink = Url.Action("ResetPassword", "Account", new {Email=model.Email , Token = token} , Request.Scheme);
                    var email = new Email()
                    {
                        Title = "Reset Password",
                        To = model.Email,
                        Body = resetPasswordLink
                    };
                    EmailSettings.SendEmail(email);
                    return RedirectToAction(nameof(CompleteForgetPassword));
                }
                ModelState.AddModelError(string.Empty, "Email is not Existed!!");
               
            }
            return View(model);
        }
        public IActionResult CompleteForgetPassword()
        {
            return View();
        }
        #endregion
        #region Reset Password
        public IActionResult ResetPassword(string email,string token)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await UserManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
                    if (result.Succeeded)
                        return RedirectToAction(nameof(ResetPasswordDone));
                    foreach(var error in result.Errors)
                        ModelState.AddModelError(string.Empty,error.Description);
                    return View(model);
                }
                ModelState.AddModelError(string.Empty, "This email is not existed");
            }
            return View(model);
        }
        public IActionResult ResetPasswordDone()
        {
            return View();
        }
        #endregion

    }
}
