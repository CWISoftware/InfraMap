using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
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
            Property(t => t.Cor).IsOptional().HasMaxLength(50);
            HasOptional(t => t.Gerente).WithMany(t => t.ColaboradoresVinculados).HasForeignKey(t => t.GerenteId).WillCascadeOnDelete(false);
        }
    }
}
