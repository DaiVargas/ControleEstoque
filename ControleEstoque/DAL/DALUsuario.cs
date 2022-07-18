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

        //AINDA NÃO ESTÁ PRONTO, PRECISAR CHECAR SE O USUÁRIO JÁ EXISTE NO BANCO
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

        public ModeloUsuario GetRegistro(String email, String senha)
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
                //obj.Administrador = Convert.ToInt32(registro["administrador"]);
            }
            con.Close();
            return obj;
        }
    }
}