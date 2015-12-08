using System;
using System.Collections.Generic;
using InfraMap.Dominio.Comum;

namespace InfraMap.Dominio.Autenticacao
{
    public class Permissao : EntidadeBase
    {
        public string Texto { get; set; }

        public ICollection<Usuario.Usuario> Usuarios { get; set; }
    }
}
