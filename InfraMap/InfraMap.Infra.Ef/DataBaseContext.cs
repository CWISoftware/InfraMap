using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using InfraMap.Dominio.ModuloUsuario;
using InfraMap.Dominio.ModuloMesa;
using InfraMap.Dominio.ModuloMaquina;
using InfraMap.Dominio.ModuloRamal;
using InfraMap.Dominio.ModuloAndar;
using InfraMap.Dominio.ModuloSede;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace InfraMap.Infraestrutura.Ef
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
            : base("connectionString")
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<Maquina> Maquina { get; set; }
        public DbSet<Ramal> Ramal { get; set; }
        public DbSet<Andar> Andar { get; set; }
        public DbSet<Sede> Sede { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new Mapeamento.MapeamentoUsuario());
            modelBuilder.Configurations.Add(new Mapeamento.MapeamentoPermissao());
            modelBuilder.Configurations.Add(new Mapeamento.MapeamentoMesa());
            modelBuilder.Configurations.Add(new Mapeamento.MapeamentoMaquina());
            modelBuilder.Configurations.Add(new Mapeamento.MapeamentoRamal());
            modelBuilder.Configurations.Add(new Mapeamento.MapeamentoAndar());
            modelBuilder.Configurations.Add(new Mapeamento.MapeamentoSede());
            base.OnModelCreating(modelBuilder);
        }
    }
}
