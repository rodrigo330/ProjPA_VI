using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pa_api.Data;
using pa_api.Models;

namespace pa_api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]

    public class AlunosController : ControllerBase
    {
        private readonly DataContext _context;

        public AlunosController(DataContext context)
        {
            _context = context;
        }
        // GET api/alunos
        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        public async Task<IActionResult> GetAlunos()
        {
            var Alunos = await _context.Alunos.ToListAsync();
            return Ok(Alunos);
        }

        // GET api/alunos/5
        [HttpGet("{id}")]
        [EnableCors("AllowAnyOrigin")]
        public async Task<IActionResult> GetValue(int id)
        {
            //var value = await _context.Alunos.FirstOrDefaultAsync(x => x.Id == id);
            var value = await _context.Alunos.Include(x => x.Livros).FirstOrDefaultAsync(x => x.Id == id);

            var livros = await _context.Livros.ToListAsync();
            

            //var aux = await _context.Livros.Where(l => l.AlunoID == id).ToListAsync();
            //var value = await _context.Livros.Where(l => l.Aluno.Id == id).ToListAsync();

            return Ok(value);
        }

        // POST api/alunos
        [HttpPost]
        [EnableCors("AllowAnyOrigin")]
        public async Task<IActionResult> Post(Aluno aluno)
        {
            await _context.Alunos.AddAsync(aluno);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }

        

        // PUT api/alunos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Aluno value)
        {

            Aluno aluno = await _context.Alunos.FirstOrDefaultAsync(x => x.Id == id);
            if(aluno != null) {
                aluno.Nome = value.Nome;
                aluno.livrosDoados = value.livrosDoados;
                aluno.DataEntrada = value.DataEntrada;

                await _context.SaveChangesAsync();
                return StatusCode(201);
            }
            return StatusCode(400);
        }

        // DELETE api/alunos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Aluno aluno = await _context.Alunos.FirstOrDefaultAsync(x => x.Id == id);
            if(aluno != null) {
                _context.Alunos.Remove(aluno);

                await _context.SaveChangesAsync();
            }

            return StatusCode(201);


        }






        // POST api/alunos
        [HttpPost("{id}/add")]
        [EnableCors("AllowAnyOrigin")]
        public async Task<IActionResult> PostLivro(int id, Livro livro)
        {
            await _context.Livros.AddAsync(livro);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }

        // DELETE api/alunos/5
        [HttpDelete("{id}/Delete")]
        public async Task<IActionResult> DeleteLivro(int id, Livro livro)
        {
            Livro livro2 = await _context.Livros.FirstOrDefaultAsync(x => x.Id == livro.Id);
            if(livro2 != null) {
                _context.Livros.Remove(livro2);

                await _context.SaveChangesAsync();
            }

            return StatusCode(201);
        }
    }
}