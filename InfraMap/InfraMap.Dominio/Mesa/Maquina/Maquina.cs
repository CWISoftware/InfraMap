using System;
using InfraMap.Dominio.Comum;
using System.ComponentModel.DataAnnotations;

namespace InfraMap.Dominio.Mesa.Maquina
{
    public class Maquina : EntidadeBase
    {
        public int? ModeloMaquina_Id { get; set; }
        public ModeloMaquina ModeloMaquina { get; set; }

        public TipoMaquina TipoMaquina { get; set; }

        public int? HD { get; set; }

        public int? SSD { get; set; }

        [Required(ErrorMessage = "É necessário preencher o primeiro slot de memória ram")]
        public int MemoriaRamGB1 { get; set; }

        public int? MemoriaRamGB2 { get; set; }

        public int? MemoriaRamGB3 { get; set; }

        public int? MemoriaRamGB4 { get; set; }

        [Required(ErrorMessage = "É necessário uma descrição do processador")]
        public string Processador { get; set; }

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
