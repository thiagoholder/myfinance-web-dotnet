using MyFinance.Application.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyFinance.WebApp.Models;

public class CreatePlanoContaViewModel
{

    [Required]
    [StringLength(100)]
    public string Descricao { get; set; }

    [Required]
    public TipoPlanoConta Tipo { get; set; }
}