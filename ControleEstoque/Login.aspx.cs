using ControleEstoque.DAL;
using ControleEstoque.MODELO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleEstoque
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text;
            string senha = tbSenha.Text;

            DALUsuario du = new DALUsuario();
            ModeloUsuario u = du.GetRegistroLogin(email, senha);
            if (email == u.email && senha == u.senha)
            {
                Session["id"] = u.id;
                Session["nome"] = u.nome;
                Session["email"] = email;
                Response.Redirect("~/Index.aspx");
            }
            else
            {
                lblMensagem.Text = "Email ou senha incorreto";
            }
        }
    }
}