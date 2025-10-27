<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePrincipal.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="Agenda.Web.usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Inserir Novo Usuário: "></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="E-mail: "></asp:Label>
    <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Nome: "></asp:Label>
    <asp:TextBox ID="tbNome" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Senha: "></asp:Label>
    <asp:TextBox ID="tbSenha" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btInserir" runat="server" OnClick="btInserir_Click" Text="Inserir" />
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Lista de Usuários:"></asp:Label>
    <br />


    <asp:GridView ID="GridView1" runat="server"
        AllowPaging="True" 
        Width="742px" 
        DataKeyNames="Id"
        AutoGenerateColumns="False"
        DataSourceID="ObjectDataSourceUsuarios">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="Email" HeaderText="E-mail" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Senha" HeaderText="Senha" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource ID="ObjectDataSourceUsuarios" runat="server"
        TypeName="Agenda.Svc.SvcUsuario"
        SelectMethod="ListarUsuario"
        DeleteMethod="DeletarUsuario"
        InsertMethod="InserirUsuario"
        UpdateMethod="AtualizarUsuario"
        DataObjectTypeName="Agenda.Mdl.Usuarios">
    </asp:ObjectDataSource>

        <br />
<asp:Label ID="LabelMsg" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
</asp:Content>
