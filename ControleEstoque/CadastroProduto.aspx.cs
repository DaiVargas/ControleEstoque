using ControleEstoque.DAL;
using ControleEstoque.MODELO;
using System;

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

                if (txtNome.Text != "" && txtPreco.Text != "" && txtQuantidade.Text != "") { 

                    int quantidade = Convert.ToInt32(txtQuantidade.Text);
                    if (quantidade <= 0)
                    {
                        throw new Exception("A quantidade deve ser maior que zero");
                    }
                    
                    DALProduto dal = new DALProduto();
                    ModeloProduto obj = new ModeloProduto();

                    obj.nome = txtNome.Text;
                    obj.preco = Convert.ToInt32(txtPreco.Text);
                    obj.quantidade = Convert.ToInt32(txtQuantidade.Text);
                    obj.ultimaAlteracao = Convert.ToInt32(Session["id"]);

                    ModeloProduto mp = dal.ConsultarNome(txtNome.Text);

                    dal.Inserir(obj);
                    LimpaCampos();
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

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }
    }
}