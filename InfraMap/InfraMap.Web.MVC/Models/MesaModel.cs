using InfraMap.Dominio.ModuloMaquina;
using InfraMap.Dominio.ModuloRamal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfraMap.Web.MVC.Models
{
    public class MesaModel
    {
        public int Id { get; set; }

        public int IdSede { get; set; }

        public int IdAndar { get; set; }

        public int IdMaquina { get; set; }

        public int IdRamal { get; set; }

        public String Colaborador { get; set; }

        public int IdColaborador { get; set; }

        public TipoRamal TipoRamal { get; set; }

        public TipoMaquina TipoMaquina { get; set; }

        public string Maquina { get; set; }

        public string Ramal { get; set; }

        public bool TemMaquina
        {
            get
            {
                return this.IdMaquina > 0;
            }
        }

        public bool TemRamal
        {
            get
            {
                return this.IdRamal > 0;
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
}