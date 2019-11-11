using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace pa_api.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int AlunoID { get; set; }        
        public Aluno Aluno { get; set; }
        [Column(TypeName="Date")]
        public DateTime DataEntrada { get; set; }

    }
}