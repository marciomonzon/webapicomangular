using ApiUsuario.Models;
using System.Collections.Generic;

namespace ApiUsuario.Repositorio
{
    public interface IUsuarioRepositorio
    {
        void Add(Usuario user);
        IEnumerable<Usuario> GetAll();
        Usuario Find(int id);
        void Remove(int id);
        void Update(Usuario user);
    }
}
