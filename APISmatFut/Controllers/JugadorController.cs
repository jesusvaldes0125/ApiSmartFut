using APISmatFut.Models;   
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampeonatoFutbol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController : ControllerBase
    {
        private readonly DbsmarfutContext _dbcontext;
        public JugadorController(DbsmarfutContext context)
        {
            _dbcontext = context;
        }

  
        [HttpGet]
        [Route("Listar")]
        public IActionResult Lista()
        {
            List<Jugador> lista = new List<Jugador>();
            try
            {
                lista = _dbcontext.Jugadors.Include(c => c.oEquipo).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }

        [HttpGet]
        [Route("Listar/{id:int}")]
        public IActionResult Listar(int id)
        {
            Jugador oJugador = _dbcontext.Jugadors.Find(id);
            if (oJugador == null)
            {
                return BadRequest("jugador no encontrado");
            }
            try
            {
                oJugador = _dbcontext.Jugadors.Include(c => c.oEquipo).Where(p => p.Id == id).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oJugador });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oJugador });
            }
        }


        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Jugador objeto)
        {
            try
            {
                _dbcontext.Jugadors.Add(objeto);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }


        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Jugador request)
        {
            _dbcontext.Jugadors.Update(request);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            Jugador jugador = _dbcontext.Jugadors.Find(id);
            _dbcontext.Jugadors.Remove(jugador);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }
}
