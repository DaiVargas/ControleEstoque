using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoque.MODELO
{
    public class ModeloUsuario
    {
        public int id { get; set; }
        public String nome { get; set; }
        public String email { get; set; }
        public String senha { get; set; }

        public ModeloUsuario()
        {
            this.id = 0;
            this.nome = "";
            this.email = "";
            this.senha = "";
        }

    }
}