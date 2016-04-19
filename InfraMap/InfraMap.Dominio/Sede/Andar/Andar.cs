using System.Collections.Generic;
using InfraMap.Dominio.Comum;

namespace InfraMap.Dominio.Sede.Andar
{
    public class Andar : EntidadeBase
    {
        private int mesaSelecionada;

        public string Descricao { get; set; }

        public ICollection<Mesa.Mesa> Mesas { get; set; }

        //Isso foi feito pois o Atributo NotMapping não funciona. Bug no EntityFramework
        public int GetMesaSelecionada() { return mesaSelecionada; }
        public void SetMesaSelecionada(int idMesa) { mesaSelecionada = idMesa; }
    }
}
