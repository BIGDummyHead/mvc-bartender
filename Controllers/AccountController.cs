using System.Security.Claims;
using cis_proj.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cis_proj.Controllers;

/// <summary>
/// Handles staff sign in and sign out.
/// </summary>
public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Displays the staff login form.
    /// </summary>
    /// <param name="returnUrl">Where to send the user after they sign in</param>
    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    /// <summary>
    /// Checks the email and password against the Users table and signs the
    /// staff member in with a cookie.
    /// </summary>
    /// <param name="email">The staff member's email</param>
    /// <param name="password">The staff member's password</param>
    /// <param name="returnUrl">Where to send the user after they sign in</param>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string email, string password, string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (user == null || !PasswordHelper.Verify(password ?? "", user.Password))
        {
            ModelState.AddModelError("", "Invalid email or password.");
            return View();
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);

        return RedirectToAction("Queue", "Order");
    }

    /// <summary>
    /// Signs the staff member out.
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}
