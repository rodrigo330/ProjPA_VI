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
    //[Authorize]
    [ApiController]

    public class MarcasController : ControllerBase
    {
        private readonly DataContext _context;

        public MarcasController(DataContext context)
        {
            _context = context;
        }
        // GET api/marcas
        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        public async Task<IActionResult> GetMarcas()
        {
            var Marcas = await _context.Marcas.ToListAsync();
            return Ok(Marcas);
        }

        // GET api/marcas/5
        [HttpGet("{id}")]
        [EnableCors("AllowAnyOrigin")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Marcas.Include(x => x.Produtos).FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

        // POST api/marcas
        [HttpPost]
        [EnableCors("AllowAnyOrigin")]
        public async Task<IActionResult> Post(Marca marca)
        {
            await _context.Marcas.AddAsync(marca);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }

        

        // PUT api/marca/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Marca value)
        {

            Marca marca = await _context.Marcas.FirstOrDefaultAsync(x => x.Id == id);
            if(marca != null) {
                marca.Nome = value.Nome;
                marca.Produtos = value.Produtos;

                await _context.SaveChangesAsync();
                return StatusCode(201);
            }
            return StatusCode(400);
        }

        // DELETE api/marca/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Marca marca = await _context.Marcas.FirstOrDefaultAsync(x => x.Id == id);
            if(marca != null) {
                _context.Marcas.Remove(marca);

                await _context.SaveChangesAsync();
            }

            return StatusCode(201);


        }
    }
}