using ControleEstoque.MODELO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleEstoque.DAL
{
    public class DALUsuario
    {
        private System.Configuration.ConnectionStringSettings connString;
        
        public DALUsuario()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConexaoControleEstoque"];
        }

        public void Inserir(ModeloUsuario obj)
        {
            //cria um objeto de conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "Insert into usuario (nome, email, senha) values (@nome, @email, @senha);select @@IDENTITY;";
                cmd.Parameters.AddWithValue("nome", obj.nome);
                cmd.Parameters.AddWithValue("email", obj.email);
                cmd.Parameters.AddWithValue("senha", obj.senha);
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

        public ModeloUsuario GetRegistroLogin(String email, String senha)
        {
            ModeloUsuario obj = new ModeloUsuario();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = "select * from usuario where email = @email and senha = @senha";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                obj.id = Convert.ToInt32(registro["id"]);
                obj.email = Convert.ToString(registro["email"]);
                obj.nome = Convert.ToString(registro["nome"]);
                obj.senha = Convert.ToString(registro["senha"]);
            }
            con.Close();
            return obj;
        }

        public DataTable Localizar()
        {
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * from usuario", connString.ConnectionString);
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ModeloUsuario ConsultarEmail(String email)
        {
            ModeloUsuario obj = new ModeloUsuario();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "select * from usuario where email = @email";
                cmd.Parameters.AddWithValue("email", email);

                con.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    throw new Exception("Já existe um usuario cadastrado com esse email!");
                }

                con.Close();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int cod)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from usuario where id = " + cod.ToString();
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}