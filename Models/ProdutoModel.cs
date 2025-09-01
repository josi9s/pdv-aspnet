using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dotnet_pdv.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        
        public string Descricao { get; set; }
        public string Grupo { get; set; }
        public string Unidade { get; set; }
        public int Estoque { get; set; }
        public decimal Custo { get; set; }
        public decimal PrecoVenda { get; set; }
        public bool Ativo { get; set; }
        public string NCM { get; set; }
        public string Fornecedor { get; set; }
        public string ImagemUrl { get; set; }
    }
}