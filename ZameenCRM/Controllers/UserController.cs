using DATA.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZameenCRM.Models;

namespace ZameenCRM.Controllers
{
    public class UserController : Controller
    {
        FinalDBCotext db = new FinalDBCotext();
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            ViewBag.Key = TempData["Key"];
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginVM model)
        {
            FinalDBCotext cont = new FinalDBCotext();
            var data = cont.Users.Where(e => e.UserEmail == model.Email).FirstOrDefault();
            if (data != null)
            {
                bool isValid = (data.UserEmail == model.Email && DecryptPassword(data.Password) == model.PassWord);
                if (isValid)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,model.Email),
                };
                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity), authProperties);
                    TempData["Key"] = "Login Successfull";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Key"] = "Wrong information enter again";
                    return RedirectToAction("Login");
                }
            }
            return RedirectToAction("Login");
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpVM log)
        {
            var User1 = new Users()
            {
                UserName = log.UserName,
                UserEmail = log.Email,
                Password = EncryptPassword(log.Password)
            };
            db.Users.Add(User1);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        public static string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return null;
            }
            else
            {
                byte[] storepassword = System.Text.ASCIIEncoding.ASCII.GetBytes(password);
                string encryptPassword = Convert.ToBase64String(storepassword);
                return encryptPassword;
            }
        }
        public static string DecryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return null;
            }
            else
            {
                byte[] encryptedPassword = Convert.FromBase64String(password);
                string decryptPassword = ASCIIEncoding.ASCII.GetString(encryptedPassword);
                return decryptPassword;
            }
        }
    }
}
