using InfraMap.Dominio.Mesa.Maquina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfraMap.Web.MVC.Models
{
    public class ListaMaquinaModel
    {
        public List<MaquinaPessoal> Maquinas { get; set; }
    }
}