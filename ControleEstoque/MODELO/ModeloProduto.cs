using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoque.MODELO
{
    public class ModeloProduto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int preco { get; set; }
        public int quantidade { get; set; }
        public int ultimaAlteracao { get; set; }

        public ModeloProduto()
        {
            this.id = 0;
            this.nome = "";
            this.preco = 0;
            this.quantidade = 0;
            this.ultimaAlteracao = 0;
        }
    }
}