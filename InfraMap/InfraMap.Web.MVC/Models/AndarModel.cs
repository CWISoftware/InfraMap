using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Sede.Andar;

namespace InfraMap.Web.MVC.Models
{
    public class AndarModel
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public List<MesaModel> Mesas { get; set; }

        public AndarModel(Andar andar)
        {
            this.Id = andar.Id;
            this.Descricao = andar.Descricao;
            this.Mesas = new List<MesaModel>();
            foreach (var mesa in andar.Mesas)
            {
                this.Mesas.Add(new MesaModel(mesa));
            }
        }
    }
}
