namespace MyFinance.Domain.Models;

public class PlanoConta: EntityBase
{
    public PlanoConta(Guid id, string descricao, TipoPlanoConta tipo) : base(id)
    {
        Descricao = descricao;
        Tipo = tipo;
    }
    public PlanoConta(string descricao, TipoPlanoConta tipo):base()
    {
        Descricao = descricao;
        Tipo = tipo; 
    }

    public string Descricao { get; private set; }
    public TipoPlanoConta Tipo { get; private set; }
}