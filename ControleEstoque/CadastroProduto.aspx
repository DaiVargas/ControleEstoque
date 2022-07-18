<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CadastroProduto.aspx.cs" Inherits="ControleEstoque.CadastroProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3><span class="badge badge-secondary">Cadastro de Produtos</span></h3>
    <br />
    <div class="form-group">
        <label>Nome do Produto</label>
        <asp:TextBox class="form-control" Width="50%" runat="server" ID="txtNome" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNome" ErrorMessage="Informe um nome de usuário" Font-Bold="True" ForeColor="Maroon"></asp:RequiredFieldValidator>
        <label>Quantidade</label>
        <asp:TextBox class="form-control" Width="20%" runat="server" ID="txtQuantidade" />

        <label>Preço</label>
        <asp:TextBox class="form-control" Width="20%" runat="server" ID="txtPreco" />
    </div>

    <div class="form-group">
        <asp:Button ID="btnGravar" runat="server" Text="Gravar" CssClass="btn btn-success btn-sm" OnClick="btnGravar_Click" />
        <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="btn btn-warning btn-sm" OnClick="btnLimpar_Click" />
    </div>

</asp:Content>
