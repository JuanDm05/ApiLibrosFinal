using ApiLibrosFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using ProyectoApiLibros;
using ApiLibrosFinal.Models;

namespace ProyectoApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        public readonly Librosv2Context _dbcontext;

        public AutorController(Librosv2Context _context)
        {
            _dbcontext = _context;
        }
        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Autor> lista = new List<Autor>();
            try
            {
                lista = _dbcontext.Autors.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex, response = lista });
            }

        }
        [HttpGet]
        [Route("Obtener/{idAutor:int}")]
        public IActionResult Obtener(int idAutor) // Corregido el nombre del parámetro
        {
            try
            {
                Autor oAutor = _dbcontext.Autors.Find(idAutor);

                if (oAutor == null)
                {
                    return NotFound("Autor no encontrado");
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oAutor });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        [HttpPost]
        [Route("Insertar")]
        public IActionResult Insertar([FromBody] Autor autor)
        {
            try
            {
                if (autor == null)
                {
                    return BadRequest("Los datos del Autor son nulos");
                }

                Autor nuevoAutor = new Autor
                {
                    Nombre = autor.Nombre,
                    Pais = autor.Pais,
                    Apellidos = autor.Apellidos
                    // Agrega otros campos de Autor que desees incluir aquí
                };

                _dbcontext.Autors.Add(nuevoAutor);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = "Autor insertado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }


        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Autor autor)
        {
            Autor oAutor = _dbcontext.Autors.Find(autor.IdAutor);

            if (oAutor == null)
            {
                return NotFound("Autor no encontrado");
            }

            try
            {
                // Actualiza todos los campos del autor que se hayan enviado
                oAutor.Nombre = autor.Nombre ?? oAutor.Nombre;
                oAutor.Pais = autor.Pais ?? oAutor.Pais;
                oAutor.Apellidos = autor.Apellidos ?? oAutor.Apellidos;
                //oAutor.LibroAutors = autor.LibroAutors ?? oAutor.LibroAutors;
                // Agrega otros campos de Autor que desees incluir aquí

                _dbcontext.Autors.Update(oAutor);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = "Autor actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        [HttpDelete]
        [Route("Eliminar/{idAutor:int}")]
        public IActionResult Eliminar(int idAutor)
        {
            Autor oAutor = _dbcontext.Autors.Find(idAutor);

            if (oAutor == null)
            {
                return NotFound("Autor no encontrado");
            }

            try
            {
               

                _dbcontext.Autors.Remove(oAutor);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = "Autor actualizado Eliminado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }

        }

    }
}
