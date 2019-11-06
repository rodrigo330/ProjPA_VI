using Microsoft.EntityFrameworkCore;
using pa_api.Models;

namespace pa_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions <DataContext> options) : base (options){}

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}