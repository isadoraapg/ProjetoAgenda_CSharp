using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda.Web
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btLogar_Click(object sender, EventArgs e)
        {
            //verificar se as infos coincidem com o usuario existente
            String email = tbEmailLogin.Text;
            String senha = tbSenhaLogin.Text;

            //

            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from usuario where email = @email and senha = @senha";
            
            cmd.Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue("senha", senha);
            con.Open();

            //jogar os dados em um data reader - executa o comando e verifica se tem algum registro com os parametros
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                //cria um cookie e armazena o email para saber se o usuario esta conectado ou nao
                HttpCookie login = new HttpCookie("login", tbEmailLogin.Text);
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
    }
}