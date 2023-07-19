namespace MyFinance.Domain.Models
{
    public class EntityBase
    {
        public Guid Id { get; }

        public EntityBase()
		{
			Id = Guid.NewGuid();
		}

        public EntityBase(Guid id)
        {
            Id = id;
        }
	}
}

