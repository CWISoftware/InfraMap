using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using InfraMap.Dominio.Comum;

namespace InfraMap.Dominio.Usuario
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }

        public string Login { get; set; }

        public string Cor { get; set; }

        public int? GerenteId { get; set; }

        public virtual Usuario Gerente { get; set; }

        public virtual ICollection<Usuario> ColaboradoresVinculados { get; set; }

        [NotMapped]
        public List<string> Permissoes;

        public Usuario() { }

        public Usuario(string login, string nome, List<string> permissoes)
        {
            this.Login = login;
            this.Nome = nome;
            this.Permissoes = permissoes;
        }
    }
}
