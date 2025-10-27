using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agenda.Mdl;
using Agenda.Svc;

namespace Agenda.Web
{
    public partial class contatos : System.Web.UI.Page
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
                Contato novoContato = new Contato
                {
                    Nome = tbNome.Text,
                    Email = tbEmail.Text,
                    Telefone = tbTelefone.Text
                };

               
                SvcContato.InserirContato(novoContato);

                //limpa os campos depois de inserir
                tbNome.Text = string.Empty;
                tbEmail.Text = string.Empty;
                tbTelefone.Text = string.Empty;
                 
                GridView1.DataBind();

                Response.Write("<script>alert('Contato inserido com sucesso!');</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Erro: {ex.Message}');</script>");
            }
        }

        //private void CarregarGrid() 
        //{
        //    GridView1.DataSource = SvcContato.ListarContato(); //fonte de dados - lista do svc
        //    GridView1.DataBind(); //q faz os dados aparecerem
        //}

        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    try
        //    {
        //        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value); //pega o id do gridview, converte pra int
        //        SvcContato.DeletarContato(id);  //chama o deletar passando o id
        //        CarregarGrid(); //depois recarrega o grid
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write($"<script>alert('Erro ao deletar: {ex.Message}');</script>");
        //    }
        //}

        //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridView1.EditIndex = e.NewEditIndex; //modo edição do grifd (mostra textbox nos campos para poder edirar)
        //    CarregarGrid();
        //}

        //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridView1.EditIndex = -1; //sai do modo edição
        //    CarregarGrid();
        //}

        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e) //chamado qnd usuario clica em atualizar
        //{
        //    try
        //    {
        //        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value); //pega o id q ta sendo atualizado

        //        TextBox tbNomeEdit = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]; //pega o textbox q o grid cria automaticamente nas celulas da linha q ta sendo editada
        //        TextBox tbEmailEdit = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
        //        TextBox tbTelefoneEdit = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];

        //        //cells[1] segunda coluna
        //        //controls[0] primeiro controle dentro da celula - textbox de edição

        //        SvcContato.AtualizarContato(id, tbNomeEdit.Text, tbEmailEdit.Text, tbTelefoneEdit.Text); //chama o metodo atualizar passando os parametros

        //        GridView1.EditIndex = -1;
        //        CarregarGrid();
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write($"<script>alert('Erro ao atualizar: {ex.Message}');</script>");
        //    }
        //}


    }    
    
}