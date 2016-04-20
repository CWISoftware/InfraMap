using System.ComponentModel.DataAnnotations;

namespace InfraMap.Dominio.Mesa.Ramal
{
    public enum TipoRamal
    {
        [Display(Name = "Digital")]
        Digital,
        [Display(Name = "Analógico")]
        Analogico
    }
}
