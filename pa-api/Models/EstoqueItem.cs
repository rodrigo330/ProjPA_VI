using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pa_api.Models
{
    public class EstoqueItem
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        [Column(TypeName="Date")]
        public DateTime DataAdicao { get; set; }
        [Column(TypeName="Date")]
        public DateTime DataVencimento { get; set; }
    }
}