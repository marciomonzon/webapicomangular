using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Models
{
    public class Usuario
    {
        public int usuarioid { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
    }
}
