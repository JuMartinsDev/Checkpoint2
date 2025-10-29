using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nac2Estoque.Models
{
    public enum Categoria
    {
        PERECIVEL,
        NAO_PERECIVEL
    }

    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string CodigoSKU { get; set; } = string.Empty;

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public Categoria Categoria { get; set; }

        [Required]
        public decimal PrecoUnitario { get; set; }

        [Required]
        public int QuantidadeMinima { get; set; }

        [Required]
        public int QuantidadeAtual { get; set; } = 0;

        [Required]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public ICollection<MovimentacaoEstoque>? Movimentacoes { get; set; }
    }
}
