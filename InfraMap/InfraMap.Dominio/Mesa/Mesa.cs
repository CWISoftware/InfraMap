using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Comum;
using InfraMap.Dominio.Sede.Andar;

namespace InfraMap.Dominio.Mesa
{
    public class Mesa : EntidadeBase
    {
        public int? Colaborador_Id { get; set; }
        public Usuario.Usuario Colaborador { get; set; }

        public int? MaquinaPessoal_Id { get; set; }
        public Maquina.MaquinaPessoal MaquinaPessoal { get; set; }

        public int Andar_Id { get; set; }
        public Andar Andar { get; set; }

        public int? Ramal_Id { get; set; }
        public Ramal.Ramal Ramal { get; set; }

        public string PontoLogico1 { get; set; }
        public string PontoLogico2 { get; set; }
        public string PontoEletrico { get; set; }

        public void AdicionarColaborador(Usuario.Usuario colaborador)
        {
            this.Colaborador = colaborador;
            this.Colaborador_Id = colaborador.Id;
        }

        public void RemoverColaborador()
        {
            this.Colaborador = null;
            this.Colaborador_Id = null;
        }

        public void AdicionarMaquina(Maquina.MaquinaPessoal maquinaPessoal)
        {
            this.MaquinaPessoal = maquinaPessoal;
            this.MaquinaPessoal_Id = maquinaPessoal.Id;
        }

        public void RemoverMaquina()
        {
            this.MaquinaPessoal = null;
            this.MaquinaPessoal_Id = null;
        }

        public void AdicionarRamal(Ramal.Ramal ramal)
        {
            this.Ramal = ramal;
            this.Ramal_Id = ramal.Id;
        }

        public void RemoverRamal()
        {
            this.Ramal = null;
            this.Ramal_Id = null;
        }

        public bool TemMaquina
        {
            get
            {
                return this.MaquinaPessoal != null;
            }
        }

        public bool TemRamal
        {
            get
            {
                return this.Ramal != null;
            }
        }

        public bool TemColaborador
        {
            get
            {
                return this.Colaborador != null;
            }
        }

        public bool TemPontoLogico1
        {
            get
            {
                return this.PontoLogico1 != null;
            }
        }

        public bool TemPontoLogico2
        {
            get
            {
                return this.PontoLogico2 != null;
            }
        }

        public bool TemPontoEletrico
        {
            get
            {
                return this.PontoEletrico != null;
            }
        }
    }
}
