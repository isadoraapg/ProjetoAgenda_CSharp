using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda.Web
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //pra remover o cookie de login e sair 
            if (Request.Cookies["login"] != null)
            {
                HttpCookie loginCookie = new HttpCookie("login");
                loginCookie.Expires = DateTime.Now.AddDays(-1); 
                Response.Cookies.Add(loginCookie);
            }

            Response.Redirect("~/login.aspx");
        }
    }
}