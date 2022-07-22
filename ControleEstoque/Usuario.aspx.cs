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
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            atualizarLista();
            pnUsuario.Visible = false;
        }

        public void LimpaCampos()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
        }

        private void atualizarLista()
        {
            try
            {
                DALUsuario dal = new DALUsuario();
                gvDados.DataSource = dal.Localizar();
                gvDados.DataBind();
            }
            catch (Exception erro)
            {
                Response.Write("<script> alert('" + erro.Message + "'); </script>");
            }

        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            pnUsuario.Visible = true;
            btnNovo.Visible = false;
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                String msg;

                if (txtNome.Text != "" && txtEmail.Text != "" && txtSenha.Text != "")
                {
                    DALUsuario dal = new DALUsuario();
                    ModeloUsuario obj = new ModeloUsuario();

                    obj.nome = txtNome.Text;
                    obj.email = txtEmail.Text;
                    obj.senha = txtSenha.Text;

                    ModeloUsuario mp = dal.ConsultarEmail(txtEmail.Text);

                    dal.Inserir(obj);
                    atualizarLista();
                    msg = "<script> alert('Cadastro realizado com sucesso. O código gerado foi: " + obj.id.ToString() + "'); </script>";

                }
                else
                {
                    throw new Exception("Todos os campos precisam ser preenchidos");
                }
                Response.Write(msg);

            }
            catch (Exception erro)
            {
                Response.Write("<script> alert('" + erro.Message + "'); </script>");
            }

        }

        protected void gvDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btExcluir")
            {
                
                    int index = Convert.ToInt32(e.CommandArgument);
                    int cod = Convert.ToInt32(gvDados.Rows[index].Cells[0].Text);

                    DALUsuario dal = new DALUsuario();
                    DALProduto dp = new DALProduto();

                    dal.Excluir(cod);
                    atualizarLista();
               
            }
            
        }
    }
}