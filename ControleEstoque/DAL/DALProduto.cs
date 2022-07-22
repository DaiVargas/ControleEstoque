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
                cmd.CommandText = "Insert into produto (nome, preco, quantidade, ultimaAlteracao) values (@nome, @preco, @quantidade, @ultimaAlteracao);select @@IDENTITY;";
                cmd.Parameters.AddWithValue("nome", obj.nome);
                cmd.Parameters.AddWithValue("preco", obj.preco);
                cmd.Parameters.AddWithValue("quantidade", obj.quantidade);
                cmd.Parameters.AddWithValue("ultimaAlteracao", obj.ultimaAlteracao);
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
                cmd.CommandText = "update produto set nome=@nome, quantidade=@quantidade, preco=@preco, ultimaAlteracao=@ultimaAlteracao where id = @id;";
                cmd.Parameters.AddWithValue("nome", obj.nome);
                cmd.Parameters.AddWithValue("quantidade", 0);
                cmd.Parameters.AddWithValue("preco", obj.preco);
                cmd.Parameters.AddWithValue("ultimaAlteracao", obj.ultimaAlteracao);
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

            try
            {
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
                    obj.ultimaAlteracao = Convert.ToInt32(registro["ultimaAlteracao"]);

                }
                con.Close();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Alterar(ModeloProduto obj)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "update produto set nome=@nome, quantidade=@quantidade, preco=@preco, ultimaAlteracao=@ultimaAlteracao where id = @id;";
                cmd.Parameters.AddWithValue("nome", obj.nome);
                cmd.Parameters.AddWithValue("quantidade", obj.quantidade);
                cmd.Parameters.AddWithValue("preco", obj.preco);
                cmd.Parameters.AddWithValue("ultimaAlteracao", obj.ultimaAlteracao);
                cmd.Parameters.AddWithValue("id", obj.id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ModeloProduto ConsultarNome(String nome)
        {
            ModeloProduto obj = new ModeloProduto();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "select * from produto where nome = @nome";
                cmd.Parameters.AddWithValue("@nome", nome);

                con.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    throw new Exception("Já existe um produto cadastrado com esse nome!");
                }

                con.Close();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ModeloProduto ConsultarNomeAlterar(String nome, int id)
        {
            ModeloProduto obj = new ModeloProduto();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "select * from produto where nome = @nome and id != @id";
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("id", id);

                con.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    throw new Exception("Já existe um produto cadastrado com esse nome!");
                }

                con.Close();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ModeloProduto ConsultarIdAlteracao(int codigo)
        {
            ModeloProduto obj = new ModeloProduto();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "select * from produto where ultimaAlteracao = @ultimaAlteracao";
                cmd.Parameters.AddWithValue("@ultimaAlteracao", codigo);

                con.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    throw new Exception("Usuario não pode ser excluido, pois existe vinculo com a tabela produtos!");
                }

                con.Close();
                return obj;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}