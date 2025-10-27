<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePrincipal.Master" AutoEventWireup="true" CodeBehind="contatos.aspx.cs" Inherits="Agenda.Web.contatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" Text="Inserir Novo Contato"></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Nome:"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbNome" runat="server" Width="354px"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="E-mail:"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbEmail" runat="server" Width="349px"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Telefone:"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbTelefone" runat="server" Width="330px"></asp:TextBox>
    <br />
    <asp:Button ID="btInserir" runat="server" OnClick="btInserir_Click" Text="Inserir" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Lista de Contatos:"></asp:Label>
    <br />
    <asp:GridView ID="GridView1" runat="server" 
        AllowPaging="True" 
        Width="742px" 
        DataKeyNames="Id"
        AutoGenerateColumns="False"
        DataSourceID="ObjectDataSourceContatos">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Email" HeaderText="E-mail" />
            <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource ID="ObjectDataSourceContatos" runat="server" 
        TypeName="Agenda.Svc.SvcContato"
        SelectMethod="ListarContato"
        DeleteMethod="DeletarContato"
        InsertMethod="InserirContato"
        UpdateMethod="AtualizarContato"
        DataObjectTypeName="Agenda.Mdl.Contato">
    </asp:ObjectDataSource>
</asp:Content>
