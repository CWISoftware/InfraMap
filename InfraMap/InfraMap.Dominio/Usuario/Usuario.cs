using System;
using System.Collections.Generic;
using InfraMap.Dominio.Autenticacao;
using InfraMap.Dominio.Comum;

namespace InfraMap.Dominio.Usuario
{
    public class Usuario : EntidadeBase
    {
        public String Nome { get; set; }

        public String Login { get; set; }

        public String Senha { get; set; }

        public ICollection<Permissao> Permissoes { get; set; }

        public ICollection<Usuario> ColaboradoresVinculados { get; set; } 
    }
}
