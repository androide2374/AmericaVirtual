using America_Virtual.DataBase;
using America_Virtual.Helpers;
using America_Virtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace America_Virtual.Controllers
{
    public class AccountController : Controller
    {
        Mapper mapper = new Mapper();
        // GET: Account
        public ActionResult Login(UsuarioModel model)
        {
            string errorLogin = "Error al intentar ingresar";
            UsuarioModel usuario = new UsuarioModel();
            if (ModelState.IsValid)
            {
                //Validacion de usuario.
                var result = LoginUser(model.Usuario1, model.Password);
                if (result == LoginResult.Succeed)
                {
                    usuario = mapper.EntitytoModel<Usuario, UsuarioModel>(AccountHelper.GetCurrentUser());
                    return PartialView("_LoginPartial", usuario);
                }
                else
                {
                    if (result == LoginResult.InvalidUserNamePassword)
                    {
                        errorLogin = "Usuario o contraseña incorrectos";
                        
                    }
                }

            }

            ModelState.AddModelError("", errorLogin);
            ViewBag.ErrorLogin = errorLogin;
            return PartialView("_LoginPartial", usuario);

        }
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            Session.Remove("ApplicationUser");


            Session.Abandon();
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }
        private LoginResult LoginUser(string username, string password)
        {
            //Servicio de encryptado para el password
            string passwordHash = Encryption.Encrypt(password);

            Usuario user = GetUser(username, passwordHash);
            if (user != null)
            {
                //si el usuario es correcto se guarda los datos en una variable de sesión
                AccountHelper.SetCurrentUser(user);
                return LoginResult.Succeed;
            }
            else
            {
                AccountHelper.SetCurrentUser(null);
                return LoginResult.InvalidUserNamePassword;
            }
        }
        private Usuario GetUser(string username, string hash)
        {
            //consulto en la base de datos si el usuario y contraseña son correctos
            Usuario entity;
            using (AmericaVirtualEntities connection = new AmericaVirtualEntities())
            {
                entity = connection.Usuario.FirstOrDefault(x => x.Usuario1 == username && x.Password == hash);
            }
            return entity;
        }
        public enum LoginResult : int
        {
            Succeed = 1,
            InvalidUserNamePassword = 2,
            AccountLocked = 3
        }

    }
}