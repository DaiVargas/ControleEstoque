using ControleEstoque.MODELO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleEstoque.DAL
{
    public class DALProduto
    {
        private System.Configuration.ConnectionStringSettings connString;

        public DALProduto()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConexaoControleEstoque"];
        }

        public void Inserir(ModeloProduto obj)
        {
            //cria um objeto de conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "Insert into produto (nome, preco, quantidade, ultima_alteracao_por) values (@nome, @preco, @quantidade, @ultima_alteracao_por);select @@IDENTITY;";
                cmd.Parameters.AddWithValue("nome", obj.nome);
                cmd.Parameters.AddWithValue("preco", obj.preco);
                cmd.Parameters.AddWithValue("quantidade", obj.quantidade);
                cmd.Parameters.AddWithValue("ultima_alteracao_por", obj.ultimaAlteracao);
                con.Open();
                obj.id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public void Atualizar(ModeloProduto obj)
        {
            //cria um objeto de conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "update produto set nome=@nome, quantidade=@quantidade, preco=@preco, ultima_alteracao_por=@ultima_alteracao_por where id = @id;";
                cmd.Parameters.AddWithValue("nome", obj.nome);
                cmd.Parameters.AddWithValue("quantidade", 0);
                cmd.Parameters.AddWithValue("preco", obj.preco);
                cmd.Parameters.AddWithValue("ultima_alteracao_por", obj.ultimaAlteracao);
                cmd.Parameters.AddWithValue("id", obj.id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            
        }

        public DataTable Localizar()
        {
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * from produto", connString.ConnectionString);
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ModeloProduto GetRegistro(int id)
        {
            ModeloProduto obj = new ModeloProduto();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from produto where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                obj.id = Convert.ToInt32(registro["id"]);
                obj.nome = Convert.ToString(registro["nome"]);
                obj.preco = Convert.ToInt32(registro["preco"]);
                obj.quantidade = Convert.ToInt32(registro["quantidade"]);
                obj.ultimaAlteracao = Convert.ToInt32(registro["ultima_alteracao_por"]);
                
            }
            con.Close();
            return obj;
        }
    }
}