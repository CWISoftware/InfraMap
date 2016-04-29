using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using InfraMap.Dominio.Mesa;
using InfraMap.Dominio.Mesa.Maquina;
using InfraMap.Dominio.Mesa.Ramal;
using InfraMap.Dominio.Sede;
using InfraMap.Dominio.Sede.Andar;
using InfraMap.Dominio.Usuario;

namespace InfraMap.Infraestrutura.Ef
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
            : base("connectionString")
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<Maquina> Maquina { get; set; }
        public DbSet<Ramal> Ramal { get; set; }
        public DbSet<Andar> Andar { get; set; }
        public DbSet<Sede> Sede { get; set; }
        public DbSet<MaquinaPessoal> MaquinaPessoal { get; set; }
        public DbSet<ModeloMaquina> ModeloMaquina { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new Mapeamento.MapeamentoUsuario());
            modelBuilder.Configurations.Add(new Mapeamento.MapeamentoMesa());
            modelBuilder.Configurations.Add(new Mapeamento.MapeamentoMaquina());
            modelBuilder.Configurations.Add(new Mapeamento.MapeamentoRamal());
            modelBuilder.Configurations.Add(new Mapeamento.MapeamentoAndar());
            modelBuilder.Configurations.Add(new Mapeamento.MapeamentoSede());
            modelBuilder.Configurations.Add(new Mapeamento.MapeamentoMaquinaPessoal());
            modelBuilder.Configurations.Add(new Mapeamento.MapeamentoModeloMaquina());
            base.OnModelCreating(modelBuilder);
        }
    }
}
