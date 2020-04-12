using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pa_api.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Marca Marca { get; set; }
        [Column(TypeName="money")]
        public decimal Valor { get; set; }
    }
}