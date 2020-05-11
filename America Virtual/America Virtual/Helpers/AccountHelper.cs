using America_Virtual.DataBase;
using America_Virtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace America_Virtual.Helpers
{
    public class AccountHelper
    {
        public static void SetCurrentUser(Usuario user)
        {
            if (user == null)
                HttpContext.Current.Session.RemoveAll();
            else
                HttpContext.Current.Session["ApplicationUser"] = user;
        }
        public static Usuario GetCurrentUser()
        {
            return HttpContext.Current.Session["ApplicationUser"] as Usuario;
        }

    }
}