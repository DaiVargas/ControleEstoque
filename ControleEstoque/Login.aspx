<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ControleEstoque.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <webopt:BundleReference runat="server" Path="~/Content/css" />

</head>
<body>
    <section class="vh-100">
        <div class="container-fluid h-custom" style="margin-top: auto">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-md-9 col-lg-6 col-xl-5">
                    <img src="IMAGENS/ControleEstoque.jpeg" class="img-fluid" alt="Sample image" />
                </div>
                <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
                    <form id="form1" runat="server">

                        <p>
                            <asp:Label ID="lblMensagem" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#ff0000" />
                        </p>

                        <!-- Email -->
                        <div class="form-outline mb-4">
                            <asp:TextBox ID="tbEmail" runat="server" placeholder="Informe um e-mail válido" CssClass="form-control" />
                            <label class="form-label" for="form3Example3">E-mail</label>
                        </div>

                        <!-- Senha -->
                        <div class="form-outline mb-3">
                            <asp:TextBox ID="tbSenha" runat="server" placeholder="Informe a senha" CssClass="form-control" />
                            <label class="form-label" for="form3Example4">Senha</label>
                        </div>

                        <div class="text-center text-lg-start mt-4 pt-2">
                            <asp:Button ID="btnLogar" runat="server" Text="Logar" CssClass="btn btn-primary btn-lg" OnClick="btnLogar_Click" />
                        </div>

                    </form>
                </div>
            </div>
        </div>
        <div
            class="d-flex flex-column flex-md-row text-center text-md-start justify-content-between py-4 px-4 px-xl-5 bg-primary">
        </div>
    </section>
</body>
</html>
