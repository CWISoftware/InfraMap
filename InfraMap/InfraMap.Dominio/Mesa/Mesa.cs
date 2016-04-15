using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Comum;

namespace InfraMap.Dominio.Mesa
{
    public class Mesa : EntidadeBase
    {
        public int? Colaborador_Id { get; set; }
        public Usuario.Usuario Colaborador { get; set; }

        public int? Maquina_Id { get; set; }
        public Maquina.Maquina Maquina { get; set; }

        public int? Ramal_Id { get; set; }
        public Ramal.Ramal Ramal { get; set; }

        public string PontoRede { get; set; }
        public string PontoTelefone { get; set; }
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

        public void AdicionarMaquina(Maquina.Maquina maquina)
        {
            this.Maquina = maquina;
            this.Maquina_Id = maquina.Id;
        }

        public void RemoverMaquina()
        {
            this.Maquina = null;
            this.Maquina_Id = null;
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
    }
}
