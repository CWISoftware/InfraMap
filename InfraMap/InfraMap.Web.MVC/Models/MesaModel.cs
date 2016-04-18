using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfraMap.Dominio.Mesa;
using InfraMap.Dominio.Mesa.Maquina;
using InfraMap.Dominio.Mesa.Ramal;
using InfraMap.Dominio.Usuario;

namespace InfraMap.Web.MVC.Models
{
    public class MesaModel
    {
        public int Id { get; set; }

        public int IdSede { get; set; }

        public int IdAndar { get; set; }

        public MaquinaPessoal Maquina { get; set; }

        public Ramal Ramal { get; set; }

        public Usuario Colaborador { get; set; }

        public MesaModel(Mesa mesa)
        {
            this.Id = mesa.Id;
            if (mesa.Colaborador != null)
            {
                mesa.Colaborador.Nome.Truncate(22);
                this.Colaborador = mesa.Colaborador;
            }

            if (mesa.MaquinaPessoal != null)
            {
                this.Maquina = mesa.MaquinaPessoal;
            }

            if (mesa.Ramal != null)
            {
                this.Ramal = mesa.Ramal;
            }
        }

        public bool TemMaquina
        {
            get
            {
                return this.Maquina != null;
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
    }

    public class RamalModel
    {
        public int IdRamal { get; set; }

        public string Ramal { get; set; }

        public TipoRamal TipoRamal { get; set; }

        public RamalModel(Ramal ramal)
        {
            this.IdRamal = ramal.Id;
            this.Ramal = ramal.Numero + " - " + ramal.Tipo;
        }
    }

    public class ColaboradorModel
    {
        public int IdColaborador { get; set; }

        public string Colaborador { get; set; }

        public string Login { get; set; }

        public ColaboradorModel(Usuario colaborador)
        {
            this.IdColaborador = colaborador.Id;
            this.Colaborador = colaborador.Nome.Truncate(22);
            this.Login = colaborador.Login;
        }
    }
}