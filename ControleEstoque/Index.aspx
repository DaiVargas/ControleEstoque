<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ControleEstoque.Produto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="span10 offset-1">
            <div class="row">
                <h3><span class="badge badge-secondary">Lista de Produtos</span></h3>
           </div>
            <div class="row">
                <asp:GridView ID="gvDados" runat="server" CssClass="table table-hover table-striped" GridLines="None" AutoGenerateColumns="False" BackColor="#CCCCFF" OnRowDeleting="gvDados_RowDeleting" OnRowEditing="gvDados_RowEditing" >
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" HeaderText="Ação" />
                        <asp:BoundField DataField="id" HeaderText="Código" />
                        <asp:BoundField DataField="nome" HeaderText="Nome do Produto" />
                        <asp:BoundField DataField="quantidade" HeaderText="Quantidade" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    

</asp:Content>
