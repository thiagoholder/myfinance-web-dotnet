namespace MyFinance.Application.Dto;

public class Transacao
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
    public string Historico { get; set; }
    public Guid PlanoContaId { get; set; }
    public string PlanoConta { get; set; }
}