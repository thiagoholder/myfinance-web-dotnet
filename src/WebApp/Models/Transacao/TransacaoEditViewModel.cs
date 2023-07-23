using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MyFinance.WebApp.Models;

public class TransacaoEditViewModel
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Data da Transação")]
    public DateTime Data { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    public decimal Valor { get; set; }

    [Required]
    public string Historico { get; set; }

    [Required]
    public Guid PlanoContaId { get; set; }
}