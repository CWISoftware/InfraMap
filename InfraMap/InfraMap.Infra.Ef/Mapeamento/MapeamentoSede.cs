using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Sede;

namespace InfraMap.Infraestrutura.Ef.Mapeamento
{
    public class MapeamentoSede : MapeamentoEntidade<Sede>
    {
        public MapeamentoSede()
        {
            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Sede_Nome"){ IsUnique = false} ));
            Property(t => t.Cidade).IsRequired().HasMaxLength(100);
            Property(t => t.Imagem).IsRequired().HasMaxLength(100);
            HasMany(t => t.Andares).WithRequired();
        }
    }
}
