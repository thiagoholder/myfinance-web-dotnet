namespace MyFinance.Application.Dto
{
    public class PlanoConta
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public TipoPlanoConta Tipo { get; set; }
    }
}