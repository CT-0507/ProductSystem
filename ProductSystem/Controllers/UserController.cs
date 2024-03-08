using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductSystem.Common;
using ProductSystem.Models;
using ProductSystem.Services;
using System;

namespace ProductSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        //[HttpGet("/login")]
        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            LoginPageModel model = new LoginPageModel();
            return View("Login",model);
        }

        [HttpPost]
        public IActionResult LoginUser(LoginPageModel model)
        {
            model.ErrorMessage = string.Empty;
            if (string.IsNullOrEmpty(model.UserName))
            {
                model.ErrorMessage = MessageConst.MSS_001;
                return View("Login", model);
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                model.ErrorMessage = MessageConst.MSS_002;
                return View("Login", model) ;
            }
            try
            {

                var foundUser = _userService.getUserByUserNameAndPassword(model.UserName, model.Password);
                TempData["User"] = foundUser;
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                model.ErrorMessage = "Server down";
                return View("Login", model);
            }
            return RedirectToAction("Index", "Product");
        }
    }
}
