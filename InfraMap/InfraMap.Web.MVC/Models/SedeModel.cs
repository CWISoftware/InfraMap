using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Web.MVC.Models
{
    public class SedeModel
    {
        public int IdSede { get; set; }

        public List<AndarModel> ListaAndares { get; set; }

        public SedeModel()
        {
            this.ListaAndares = new List<AndarModel>();
        }
    }
}
