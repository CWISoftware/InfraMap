using System;
using InfraMap.Dominio.Comum;

namespace InfraMap.Dominio.Mesa.Maquina
{
    public class Maquina : EntidadeBase
    {
        public int? ModeloMaquina_Id { get; set; }
        public ModeloMaquina ModeloMaquina { get; set; }

        public TipoMaquina TipoMaquina { get; set; }

        public int? HD { get; set; }

        public int? SSD { get; set; }

        public int PenteMemoriaRamGB { get; set; }

        public int UnidadesMemoriaRam { get; set; }

        public string Fonte { get; set; }

        public string PlacaMae { get; set; }

        public string Processador { get; set; }

        public string PlacaRede { get; set; }

        public string DriverOtico { get; set; }

        public void AdicionarModelo(ModeloMaquina modelo)
        {
            this.ModeloMaquina = modelo;
            this.ModeloMaquina_Id = modelo.Id;
        }

        public void RemoverModelo()
        {
            this.ModeloMaquina = null;
            this.ModeloMaquina_Id = null;
        }
    }
}
