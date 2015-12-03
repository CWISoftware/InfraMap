using InfraMap.Dominio.ModuloAndar;
using InfraMap.Dominio.ModuloColaborador;
using InfraMap.Dominio.ModuloGerente;
using InfraMap.Dominio.ModuloMaquina;
using InfraMap.Dominio.ModuloMesa;
using InfraMap.Dominio.ModuloRamal;
using InfraMap.Dominio.ModuloSede;
using InfraMap.Dominio.ModuloUsuario;
using InfraMap.Infra.Ef.Mapeamento;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infra.Ef
{
    class CodeFirst : DbContext
    {
        public CodeFirst() : base("INFRAMAP")
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<Sede> Sede { get; set; }
        public DbSet<Ramal> Ramal { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<Maquina> Maquina { get; set; }
        public DbSet<Gerente> Gerente { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Andar> Andar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MapeamentoAndar());
            modelBuilder.Configurations.Add(new MapeamentoColaborador());
            modelBuilder.Configurations.Add(new MapeamentoGerente());
            modelBuilder.Configurations.Add(new MapeamentoMaquina());
            modelBuilder.Configurations.Add(new MapeamentoMesa());
            modelBuilder.Configurations.Add(new MapeamentoRamal());
            modelBuilder.Configurations.Add(new MapeamentoSede());
            modelBuilder.Configurations.Add(new MapeamentoPermissao());
            modelBuilder.Configurations.Add(new MapeamentoUsuario());
            base.OnModelCreating(modelBuilder);
        }
    }
}
