using ControleEstoque.DAL;
using ControleEstoque.MODELO;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControleEstoque
{
    public partial class Produto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            atualizarLista();
            pnAlterar.Visible = false;
        }

        private void atualizarLista()
        {
            try
            {
                DALProduto dal = new DALProduto();
                gvDados.DataSource = dal.Localizar();
                gvDados.DataBind();
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

                DALProduto dal = new DALProduto();
                ModeloProduto p = dal.GetRegistro(cod);

                dal.Atualizar(p);
                atualizarLista();
            }
            else if(e.CommandName == "btEditar")
            {
                pnAlterar.Visible = true;
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    int cod = Convert.ToInt32(gvDados.Rows[index].Cells[0].Text);
                    DALProduto dal = new DALProduto();
                    ModeloProduto mp = dal.GetRegistro(cod);
                    if (mp.id != 0)
                    {
                        txtNome.Text = mp.nome;
                        txtQuantidade.Text = mp.quantidade.ToString();
                        txtPreco.Text = mp.preco.ToString();
                        txtCodigo.Text = mp.id.ToString();
                    }
                }
                catch (Exception erro)
                {
                    Response.Write("<script> alert('" + erro.Message + "'); </script>");
                }
                
            }
        }

        protected void gvDados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDados.PageIndex = e.NewPageIndex;
            atualizarLista();
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            pnAlterar.Visible = false;
            atualizarLista();
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                String msg;

                if (txtNome.Text != "" && txtPreco.Text != "" && txtQuantidade.Text != "")
                {
                    int quantidade = Convert.ToInt32(txtQuantidade.Text);
                    if (quantidade <= 0)
                    {
                        throw new Exception("A quantidade deve ser maior que zero");
                    }

                    int codigo = Convert.ToInt32(txtCodigo.Text);
                    DALProduto dal = new DALProduto();
                    ModeloProduto obj = new ModeloProduto();
                        
                    obj.nome = txtNome.Text;
                    obj.preco = Convert.ToInt32(txtPreco.Text);
                    obj.quantidade = Convert.ToInt32(txtQuantidade.Text);
                    obj.ultimaAlteracao = Convert.ToInt32(Session["id"]);
                    obj.id = Convert.ToInt32(txtCodigo.Text);

                    ModeloProduto mp = dal.ConsultarNomeAlterar(txtNome.Text, codigo);

                    dal.Alterar(obj);

                    msg = "<script> alert('Cadastro atualizado com sucesso.'); </script>";
                    pnAlterar.Visible = false;
                    atualizarLista();
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
    }   
}