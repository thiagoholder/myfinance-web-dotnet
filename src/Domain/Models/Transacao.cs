namespace MyFinance.Domain.Models;

public class Transacao : EntityBase
{
    private Transacao(Guid id, DateTime data, decimal valor, string historico) : base(id)
    {
        Data = data;
        Valor = valor;
        Historico = historico;
    }

    public Transacao(Guid id, DateTime data, decimal valor, string historico, PlanoConta planoConta) : this(id, data, valor, historico)
    {
        ItemPlanoConta = planoConta ?? throw new ArgumentNullException(nameof(planoConta));
    }

    public Transacao(DateTime data, decimal valor, string historico, PlanoConta planoConta) : base()
    {
        Data = data == default ? DateTime.UtcNow : data;
        Valor = valor;
        Historico = historico;
        ItemPlanoConta = planoConta ?? throw new ArgumentNullException(nameof(planoConta));
    }

    public DateTime Data { get; private set; }
    public decimal Valor { get; private set; }
    public string Historico { get; private set; }
    public PlanoConta ItemPlanoConta { get; private set; }
}