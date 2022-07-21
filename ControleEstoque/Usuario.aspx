<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="ControleEstoque.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnUsuario" runat="server" Visible="false">
        <div class="container">
            <div class="span10 offset-1">
                <h3><span class="badge badge-secondary">Cadastro de Usuários</span></h3>
                <br />
                <div class="form-group">
                    <label>Nome do Usuário</label>
                    <asp:TextBox class="form-control" Width="50%" runat="server" ID="txtNome" />

                    <label>Email</label>
                    <asp:TextBox class="form-control" Width="20%" runat="server" ID="txtEmail" />

                    <label>Senha</label>
                    <asp:TextBox class="form-control" Width="20%" runat="server" ID="txtSenha" TextMode="Password" />
                </div>

                <div class="form-group">
                    <asp:Button ID="btnGravar" runat="server" Text="Gravar" CssClass="btn btn-success btn-sm" OnClick="btnGravar_Click" />
                    <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="btn btn-warning btn-sm" OnClick="btnLimpar_Click" />
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel runat="server">
        <div class="container">
            <div class="span10 offset-1">
                <div class="row">
                    <h3><span class="badge badge-secondary">Lista de Usuários</span></h3>
                    &nbsp &nbsp
                <asp:Button ID="btnNovo" runat="server" Text="Novo" Visible="true" CssClass="btn btn-primary" OnClick="btnNovo_Click" />
                </div>

                <div class="row">
                    <asp:GridView ID="gvDados" runat="server" CssClass="table table-hover table-striped" GridLines="None" AutoGenerateColumns="False" BackColor="#CCCCFF" OnRowCommand="gvDados_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="Código" />
                            <asp:BoundField DataField="nome" HeaderText="Nome do Usuário" />
                            <asp:BoundField DataField="email" HeaderText="Email" />
                            <asp:ButtonField Text="Excluir" CommandName="btExcluir" />
                        </Columns>

                    </asp:GridView>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
