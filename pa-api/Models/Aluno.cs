using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pa_api.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int livrosDoados { get; set; }
        [Column(TypeName="Date")]
        public DateTime DataEntrada { get; set; }

        
        public ICollection<Livro> Livros { get; set; }
    }
}