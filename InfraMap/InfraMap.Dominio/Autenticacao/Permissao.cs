using System;
using System.Collections.Generic;
using InfraMap.Comum;

namespace InfraMap.Dominio.Autenticacao
{
    public class Permissao : EntidadeBase
    {
        public string Texto { get; set; }

        public ICollection<Usuario.Usuario> Usuarios { get; set; }
    }
}
