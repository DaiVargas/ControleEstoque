<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ControleEstoque.Produto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnAlterar" runat="server" Visible="false">
        <div class="container">
            <div class="span10 offset-1">
                <asp:Label runat="server" ID="lblId">Código do Produto</asp:Label><br />
                <asp:TextBox class="form-control" Width="10%" runat="server" ID="txtCodigo" Enabled="False" /><br />

                <asp:Label runat="server" ID="lblNome">Nome do Produto</asp:Label>
                <asp:TextBox class="form-control" Width="50%" runat="server" ID="txtNome" />

                <asp:Label runat="server" ID="lblQuantidade">Quantidade</asp:Label>
                <asp:TextBox class="form-control" Width="20%" runat="server" ID="txtQuantidade" />

                <asp:Label runat="server" ID="lblPreco">Preço</asp:Label>
                <asp:TextBox class="form-control" Width="20%" runat="server" ID="txtPreco" />
            </div>
        </div>
        <br />
        <div class="container">
            <div class="span10 offset-1">
                <asp:Button ID="btnAlterar" runat="server" Text="Alterar" CssClass="btn btn-success btn-sm" OnClick="btnAlterar_Click" />
                <asp:Button ID="btnLimpar" runat="server" Text="Cancelar" CssClass="btn btn-warning btn-sm" OnClick="btnLimpar_Click" />
            </div>
        </div>
    </asp:Panel>
    <div class="container">
        <div class="span10 offset-1">
            <div class="row">
                <h3><span class="badge badge-secondary">Lista de Produtos</span></h3>
            </div>
            <div class="row">
                <asp:GridView ID="gvDados" runat="server" CssClass="table table-hover table-striped" GridLines="None" AutoGenerateColumns="False" BackColor="#CCCCFF" OnRowCommand="gvDados_RowCommand" OnPageIndexChanging="gvDados_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="Código" />
                        <asp:BoundField DataField="nome" HeaderText="Nome do Produto" />
                        <asp:BoundField DataField="quantidade" HeaderText="Quantidade" />
                        <asp:BoundField DataField="preco" HeaderText="Preço" />
                        <asp:BoundField DataField="ultimaAlteracao" HeaderText="Alterado Por" />
                        <asp:ButtonField Text="Excluir" CommandName="btExcluir" />
                        <asp:ButtonField Text="Alterar" CommandName="btEditar" />
                    </Columns>
                    <PagerSettings Mode="Numeric" PageButtonCount="4" />
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
