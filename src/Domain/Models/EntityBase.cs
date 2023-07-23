namespace MyFinance.Domain.Models
{
    public class EntityBase
    {
        public Guid Id { get; private set; }

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

