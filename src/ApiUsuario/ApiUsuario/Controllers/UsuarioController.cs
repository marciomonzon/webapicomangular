using ApiUsuario.Models;
using ApiUsuario.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Controllers
{
    [Route("api/[Controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuRepo;

        public UsuarioController(IUsuarioRepositorio usuRepo)
        {
            _usuRepo = usuRepo;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _usuRepo.GetAll();
        }

        [HttpGet("{id}", Name="GetUsuario")]
        public IActionResult GetById(int id)
        {
            var usuario = _usuRepo.Find(id);
            if (usuario == null)
                return NotFound(); // 404

            return new ObjectResult(usuario);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest(); // 400

            _usuRepo.Add(usuario);
            return CreatedAtRoute("GetUsuario", new { id = usuario.usuarioid}, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null || usuario.usuarioid != id)
                return BadRequest();

            var user = _usuRepo.Find(id);
            if (user == null)
                return NotFound();

            user.email = usuario.email;
            user.nome = usuario.nome;

            _usuRepo.Update(user);

            return new NoContentResult(); // status code 204, não existe conteudo adicional, tipo um void
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _usuRepo.Find(id);
            if (usuario == null)
                return NotFound();

            _usuRepo.Remove(id);

            return new NoContentResult();
        }
    }
}
