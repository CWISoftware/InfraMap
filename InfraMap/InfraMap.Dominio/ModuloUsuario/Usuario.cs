using InfraMap.Comum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Dominio.ModuloUsuario
{
    public class Usuario : EntidadeBase
    {
        [Required]
        public String Nome { get; set; }

        [Required]
        public String Login { get; set; }

        [Required]
        public String Senha { get; set; }

        public ICollection<Permissao> Permissoes { get; set; }

        public ICollection<Usuario> ColaboradoresVinculados { get; set; } 
    }
}
