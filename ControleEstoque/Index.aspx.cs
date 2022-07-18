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
    public partial class Produto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            atualizarLista();
        }

        private void atualizarLista()
        {
            try
            {
                DALProduto dal = new DALProduto();
                gvDados.DataSource = dal.Localizar();
                gvDados.DataBind();
            }
            catch (Exception ex)
            {
    
            }

        }

        protected void gvDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            int cod = Convert.ToInt32(gvDados.Rows[index].Cells[1].Text);

            DALProduto dal = new DALProduto();
            ModeloProduto p = dal.GetRegistro(cod);
     
            dal.Atualizar(p);
            atualizarLista();
        }

        //FALTA IMPLEMENTAR A FUNÇÃO DO BOTÃO EDITAR NO MÉTODO ABAIXO
        protected void gvDados_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int index = gvDados.SelectedIndex;
            int cod = Convert.ToInt32(gvDados.Rows[index].Cells[1].Text);
            DALProduto dal = new DALProduto();
            ModeloProduto p = dal.GetRegistro(cod);

            
        }
    }
    
}