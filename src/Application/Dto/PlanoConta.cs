using System.ComponentModel.DataAnnotations;

namespace MyFinance.Application.Dto
{
	public class PlanoConta
	{
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        [Required]
        public TipoPlanoConta Tipo { get; set; }
    }
}

