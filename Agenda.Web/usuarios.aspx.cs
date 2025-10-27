using Agenda.Mdl;
using Agenda.Svc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda.Web
{
    public partial class usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["login"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
        }

        protected void btInserir_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios novoUsuario = new Usuarios
                {
                    Email = tbEmail.Text,
                    Nome = tbNome.Text,
                    Senha = tbSenha.Text
                };

                SvcUsuario.InserirUsuario(novoUsuario);

                tbEmail.Text = string.Empty;
                tbNome.Text = string.Empty;
                tbSenha.Text = string.Empty;

                GridView1.DataBind();

                Response.Write("<script>alert('Usuario inserido com sucesso!');</script>");

            }
            catch(Exception ex) 
            {
                Response.Write($"<script>alert('Erro: {ex.Message}');</script>");
            }
        }

    }
}