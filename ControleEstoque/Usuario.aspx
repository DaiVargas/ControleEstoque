<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="ControleEstoque.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3><span class="badge badge-secondary">Cadastro de Usuários</span></h3>
    <br />
    <div class="form-group">
        <label>Nome do Usuário</label>
        <asp:TextBox class="form-control" Width="50%" runat="server" ID="txtNome" placeholder="Informe o nome do Usuário" />

        <label>Email</label>
        <asp:TextBox class="form-control" Width="20%" runat="server" ID="txtEmail" placeholder="Informe o e-mail do usuário" />

        <label>Senha</label>
        <asp:TextBox class="form-control" Width="20%" runat="server" ID="txtSenha" placeholder="Informe a senha do usuário" />
    </div>

    <div class="form-group">
        <asp:Button ID="btnGravar" runat="server" Text="Gravar" CssClass="btn btn-success btn-sm" />
        <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="btn btn-warning btn-sm" />
        <asp:Button ID="Button1" runat="server" Text="Voltar" CssClass="btn btn-danger btn-sm" />
    </div>
</asp:Content>
