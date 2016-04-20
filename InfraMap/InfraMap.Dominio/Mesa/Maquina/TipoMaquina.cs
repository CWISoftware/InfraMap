using System.ComponentModel.DataAnnotations;

namespace InfraMap.Dominio.Mesa.Maquina
{
    public enum TipoMaquina
    {
        [Display(Name = "Padrão")]
        Padrao,
        [Display(Name = "Pessoal")]
        Pessoal
    }
}
