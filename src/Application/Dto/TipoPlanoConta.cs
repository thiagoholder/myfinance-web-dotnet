using System.ComponentModel.DataAnnotations;

namespace MyFinance.Application.Dto
{
    public enum TipoPlanoConta
    {
        [Display(Name = "Débito")]
        Debito = 0,

        [Display(Name = "Crédito")]
        Credito = 1,
    }
}