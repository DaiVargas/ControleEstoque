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
    public partial class CadastroProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LimpaCampos()
        {
            txtNome.Text = "";
            txtPreco.Text = "";
            txtQuantidade.Text = "";
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                String msg;

              
                DALProduto dal = new DALProduto();
                ModeloProduto obj = new ModeloProduto();

                
               
                obj.nome = txtNome.Text;
                obj.preco = Convert.ToInt32(txtPreco.Text);
                obj.quantidade = Convert.ToInt32(txtQuantidade.Text);
                obj.ultimaAlteracao = Convert.ToInt32(Session["id"]);
                
                if ((txtNome.Text == "") || (txtPreco.Text == "") || (txtQuantidade.Text == ""))
                {
                    msg = "<script> alert('Todos os campos precisam ser preenchido!!!'); </script>";
                    
                }
                else
                {
                    dal.Inserir(obj);
                    msg = "<script> alert('Cadastro realizado com sucesso. O código gerado foi: " + obj.id.ToString() + "'); </script>";
                    //obj.Id = Convert.ToInt32(txbId.Text);
                    //dal.Alterar(obj);
                }
                Response.Write(msg);

                LimpaCampos();
            }
            catch (Exception erro)
            {
                Response.Write("<script> alert('" + erro.Message + "'); </script>");
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }
    }
}