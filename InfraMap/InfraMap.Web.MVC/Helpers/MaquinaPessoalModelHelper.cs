using InfraMap.Dominio.Mesa.Maquina;
using InfraMap.Web.MVC.Models;

namespace InfraMap.Web.MVC.Helpers
{
    public class MaquinaPessoalModelHelper
    {
        public static MaquinaPessoal ToEntity(MaquinaPessoalModel model)
        {
            return new MaquinaPessoal()
            {
                EtiquetaServico = model.EtiquetaServico,
                Patrimonio = model.Patrimonio,
                Maquina = ModelToEntity(model.Maquina)
            };
        }

        private static Maquina ModelToEntity(MaquinaModel model)
        {
            return new Maquina()
            {
                HD = model.Hd,
                SSD = model.Ssd,
                Processador = model.Processador,
                MemoriaRamGB1 = model.MemoriaRamGB1,
                MemoriaRamGB2 = model.MemoriaRamGB2,
                MemoriaRamGB3 = model.MemoriaRamGB3,
                MemoriaRamGB4 = model.MemoriaRamGB4,
                TipoMaquina = TipoMaquina.Pessoal,
                ModeloMaquina_Id = model.IdModeloMaquina
            };
        }
    }
}