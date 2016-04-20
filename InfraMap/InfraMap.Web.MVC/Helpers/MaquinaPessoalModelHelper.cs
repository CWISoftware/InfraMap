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
                DriverOtico = model.DriverOtico,
                Fonte = model.Fonte,
                HD = model.Hd,
                PlacaMae = model.PlacaMae,
                PlacaRede = model.PlacaRede,
                SSD = model.Ssd,
                Processador = model.Processador,
                PenteMemoriaRamGB = model.PenteMemoriaRamGB,
                UnidadesMemoriaRam = model.UnidadesMemoriaRam,
                TipoMaquina = TipoMaquina.Pessoal,
                ModeloMaquina_Id = model.IdModeloMaquina
            };
        }
    }
}