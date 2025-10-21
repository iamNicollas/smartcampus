using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smartCampos.Models
{
    public class objProduto
    {
            public int idProduto { get; set; }
            public string nomeProduto { get; set; }
            public int quantidadeEstoque { get; set; }
            public DateTime dta_validade { get; set; }
            public DateTime dta_cadastro { get; set; }
            public decimal preco { get; set; }
            public string descricao { get; set; }
            public int idCategoria { get; set; }
            public string nomeCategoria { get; set; }
    }

    public class objCategoria
    {
        public int idCategoria { get; set; }
        public string nomeCategoria { get; set; }
    }
}