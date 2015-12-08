using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Usuario;

namespace InfraMap.Infraestrutura.Ef.Mapeamento
{
    public class MapeamentoUsuario : MapeamentoEntidade<Usuario>
    {
        public MapeamentoUsuario()
        {
            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Usuario_Nome") { IsUnique = false }));
            Property(t => t.Login)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Usuario_Login") { IsUnique = true }));
            Property(t => t.Senha).IsRequired().HasMaxLength(64);
            HasMany(t => t.Permissoes).WithMany(t => t.Usuarios);
            HasOptional(t => t.ColaboradoresVinculados).WithMany().Map(t => t.MapKey("Gerente_Id"));
        }
    }
}
