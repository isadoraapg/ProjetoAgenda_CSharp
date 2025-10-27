using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace waAgenda
{
    public partial class MasterPagePrincipal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se for nulo direciona para pagina de login
            if (Request.Cookies["login"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            
        }
    }
}