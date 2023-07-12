using System;
namespace Domain.Models
{
	public class Transacao
	{
		public Transacao(DateTimeOffset data, decimal valor, string historico, PlanoConta planoConta)
		{
			Data = data;
			Valor = valor;
			Historico = historico;
			ItemPlanoConta = planoConta;
		}

		public int Id { get; }
		public DateTimeOffset Data { get; }
		public Decimal Valor { get;}
		public string Historico { get; }
		public PlanoConta ItemPlanoConta { get; }
	}
}

