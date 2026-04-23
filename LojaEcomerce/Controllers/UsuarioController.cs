using LojaEcomerce.interfaces;
using LojaEcomerce.Models;
using LojaEcomerce.Repositorio;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace LojaEcomerce.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (!ModelState.IsValid) return View(user);
            var usuario = _usuarioRepositorio.Validar(user.Email, user.Senha);

            if(usuario != null)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim("NivelAcesso", usuario.Nivel),
                    new Claim("UsuarioId", usuario.Id.ToString())
                };
                var indentidade = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthentcationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(indentidade),
                    new AuthenticationProperties { IsPersistent = false });

                return RedirectToAction("index", "Home");
                    
                    
            }
            return View();
        }
    }
}
