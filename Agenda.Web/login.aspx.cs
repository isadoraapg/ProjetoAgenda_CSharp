using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agenda.Svc;
using Agenda.Mdl;

namespace Agenda.Web
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // verifica se ja ta logado
            if (!IsPostBack)
            {
                HttpCookie loginCookie = Request.Cookies["login"];
                if (loginCookie != null && !string.IsNullOrEmpty(loginCookie.Value))
                {
                    // se ta logado, redireciona
                    Response.Redirect("~/index.aspx");
                }
            }
        }

        protected void btLogar_Click(object sender, EventArgs e)
        {
            try
            {
                //verificar se as infos coincidem com o usuario existente
                String email = tbEmailLogin.Text;
                String senha = tbSenhaLogin.Text;

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                {
                    Response.Write("<script>alert('Preencha e-mail e senha.');</script>");
                    return;
                }

                bool logado = SvcUsuario.LogarUsuario(email, senha);


                if (logado)
                {
                    //cria um cookie e armazena o email para saber se o usuario esta conectado ou nao
                    HttpCookie login = new HttpCookie("login", email);
                    Response.Cookies.Add(login);

                    //direcionar para a pagina principal
                    Response.Redirect("~/index.aspx");
                }
                else
                {
                    Response.Write("<script> alert('E-mail ou senha incorretos'); </script>");
                    //lMsgLogin.Text = "E-mail ou senha incorretos.";
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Erro ao fazer login: {ex.Message}');</script>");
            }
        }
    }
}