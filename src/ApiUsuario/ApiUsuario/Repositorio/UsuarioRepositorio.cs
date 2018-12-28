using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiUsuario.Models;

namespace ApiUsuario.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly UsuarioDbContext _contexto;

        public UsuarioRepositorio(UsuarioDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Add(Usuario user)
        {
            _contexto.usuario.Add(user);
            _contexto.SaveChanges();
        }

        public Usuario Find(int id)
        {
            return _contexto.usuario.FirstOrDefault(u => u.usuarioid == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _contexto.usuario.ToList();
        }

        public void Remove(int id)
        {
            var entity = _contexto.usuario.First(u => u.usuarioid == id);
            _contexto.usuario.Remove(entity);
            _contexto.SaveChanges();
        }

        public void Update(Usuario user)
        {
            _contexto.usuario.Update(user);
            _contexto.SaveChanges();
        }
    }
}
