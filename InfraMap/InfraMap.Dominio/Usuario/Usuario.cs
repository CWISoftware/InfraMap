using System;
using System.Collections.Generic;
using InfraMap.Dominio.Autenticacao;
using InfraMap.Dominio.Comum;

namespace InfraMap.Dominio.Usuario
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }

        public string Login { get; set; }

        public string Cor { get; set; }        

        public ICollection<Permissao> Permissoes { get; set; }

        public int? GerenteId { get; set; }

        public virtual Usuario Gerente { get; set; }

        public virtual ICollection<Usuario> ColaboradoresVinculados { get; set; }       
    }
}
