using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfraMap.Web.MVC.Models
{
    public class MaquinaModel
    {
        [Required]
        public int IdModeloMaquina { get; set; }

        [Required(ErrorMessage = "É necessário uma descrição do processador")]
        public string Processador { get; set; }

        [Required(ErrorMessage = "É necessário preencher o primeiro slot de memória ram")]
        public int MemoriaRamGB1 { get; set; }

        public int MemoriaRamGB2 { get; set; }

        public int MemoriaRamGB3 { get; set; }

        public int MemoriaRamGB4 { get; set; }

        public int Ssd { get; set; }

        public int Hd { get; set; }
    }
}