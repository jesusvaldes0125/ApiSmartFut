using APISmatFut.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampeonatoFutbol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresidenteController : ControllerBase
    {

        private readonly DbsmarfutContext _dbcontext;
        public PresidenteController(DbsmarfutContext context)
        {
            
            _dbcontext = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Lista()
        {
            List<Presidente> lista = await _dbcontext.Presidentes.OrderByDescending(c => c.Telefono).ToListAsync();
            return Ok(lista);
        }
        [HttpGet("Listar/{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var presidente = await _dbcontext.Presidentes.FindAsync(id);
            if (presidente == null)
            {
                return NotFound();
            }
            return Ok(presidente);
        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Presidente request)
        {
            await _dbcontext.Presidentes.AddAsync(request);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Presidente request)
        {
            _dbcontext.Presidentes.Update(request);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            Presidente presidente = _dbcontext.Presidentes.Find(id);
            _dbcontext.Presidentes.Remove(presidente);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }

}
