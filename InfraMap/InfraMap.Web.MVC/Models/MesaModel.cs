using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfraMap.Web.MVC.Models
{
    public class MesaModel
    {
        public int Id { get; set; }

        public SedeModel Sede { get; set; }

        public MaquinaModel Maquina { get; set; }

        public RamalModel Ramal { get; set; }

        public UsuarioModel Colaborador { get; set; }

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
}