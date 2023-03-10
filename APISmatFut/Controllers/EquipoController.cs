using APISmatFut.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampeonatoFutbol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {

        private readonly DbsmarfutContext _dbcontext;
        public EquipoController(DbsmarfutContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Lista()
        {
            List<Equipo> lista = await _dbcontext.Equipos.OrderByDescending(c => c.Id).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Equipo request)
        {
            await _dbcontext.Equipos.AddAsync(request);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Equipo request)
        {
            _dbcontext.Equipos.Update(request);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            Equipo equipo = _dbcontext.Equipos.Find(id);
            _dbcontext.Equipos.Remove(equipo);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }   
    
}
