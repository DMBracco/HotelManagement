using HotelManagement.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("/account-register-user")]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            var msg = new MessageViewModel();
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { Email = model.Email, UserName = model.Email };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.RoleName);
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    msg.Message = "Добавлен новый пользователь:" + user.UserName;

                    return Ok(msg);
                }
                else
                {
                    msg.Message = "Пользователь не добавлен.";

                    return Ok(msg);
                }
            }

            msg.Message = "Входные данные не верны";
            return Ok(msg);
        }

        [HttpPost("/account-login-user")]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            var msg = new MessageViewModel();

            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Email);
                    IList<string> role = new List<string> { "Роль не определена" };
                    if (user != null)
                        role = await _userManager.GetRolesAsync(user);

                    msg.Message = $"Выполнен вход пользователем: {model.Email}";
                    msg.RoleName = role;
                    msg.User = model.Email;
                    return Ok(msg);
                }
                else
                {
                    msg.Message = "Неправильный логин и (или) пароль";
                    return Ok(msg);
                }
            }

            msg.Message = "Входные данные не верны";
            return Ok(msg);
        }

        [HttpGet("/account-get-role")]
        public async Task<IActionResult> GetRole()
        {
            return Ok(await _roleManager.Roles.Select(s => s.Name).ToListAsync());
        }
    }
}
