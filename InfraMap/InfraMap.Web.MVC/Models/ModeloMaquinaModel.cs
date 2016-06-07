using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfraMap.Web.MVC.Models
{
    public class ModeloMaquinaModel
    {
        [Required]
        public string Modelo { get; set; }

        public int? HD { get; set; }

        public int? SSD { get; set; }

        [Required]
        public int MemoriaRamGB1 { get; set; }

        public int? MemoriaRamGB2 { get; set; }

        public int? MemoriaRamGB3 { get; set; }

        public int? MemoriaRamGB4 { get; set; }

        [Required]
        public string Processador { get; set; }
    }
}