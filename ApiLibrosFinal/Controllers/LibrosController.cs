using ApiLibrosFinal.Models;
using Microsoft.AspNetCore.Http;

﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLibrosFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        public readonly Librosv2Context _dbcontext;

        public LibrosController(Librosv2Context _context)
        {
            _dbcontext = _context;
        }
        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Libro> lista = new List<Libro>();
            try
            {
                lista = _dbcontext.Libros.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex, response = lista });
            }

        }
        [HttpGet]
        [Route("Obtener/{idLibro:int}")]
        public IActionResult Obtener(int idLibro) // Corregido el nombre del parámetro
        {
            try
            {
                Libro oLibro = _dbcontext.Libros.Find(idLibro);

                if (oLibro == null)
                {
                    return NotFound("Autor no encontrado");
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oLibro });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        [HttpPost]
        [Route("Insertar")]
        public IActionResult Insertar([FromBody] Libro libro)
        {
            try
            {
                if (libro == null)
                {
                    return BadRequest("Los datos del Autor son nulos");
                }

                Libro nuevoLibro = new Libro
                {
                    Titulo = libro.Titulo,
                    FechaPublicacion = libro.FechaPublicacion,
                    Categoria = libro.Categoria
                    // Agrega otros campos de Autor que desees incluir aquí
                };

                _dbcontext.Libros.Add(nuevoLibro);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = "Libro insertado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Libro libro)
        {
            Libro olibro = _dbcontext.Libros.Find(libro.IdLibro);

            if (olibro == null)
            {
                return NotFound("Autor no encontrado");
            }

            try
            {
                // Actualiza todos los campos del autor que se hayan enviado
                olibro.Titulo = libro.Titulo ?? olibro.Titulo;
                olibro.FechaPublicacion = libro.FechaPublicacion ?? olibro.FechaPublicacion;
                olibro.Categoria = libro.Categoria ?? olibro.Categoria;
                //oAutor.LibroAutors = autor.LibroAutors ?? oAutor.LibroAutors;
                // Agrega otros campos de Autor que desees incluir aquí

                _dbcontext.Libros.Update(olibro);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = "Libro actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        [HttpDelete]
        [Route("Eliminar/{IdLibro:int}")]
        public IActionResult Eliminar(int IdLibro)
        {
            Libro oLibro = _dbcontext.Libros.Find(IdLibro);

            if (oLibro == null)
            {
                return NotFound("Autor no encontrado");
            }

            try
            {


                _dbcontext.Libros.Remove(oLibro);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = "Libro actualizado Eliminado" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }

        }

    }
}
