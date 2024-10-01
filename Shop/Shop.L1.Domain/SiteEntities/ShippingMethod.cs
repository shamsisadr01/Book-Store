

using Common.L1.Domain;
using Common.L1.Domain.Exceptions;

namespace Shop.L1.Domain.SiteEntities
{
	public class ShippingMethod : BaseEntity
	{
		public ShippingMethod(int cost, string title)
		{
			NullOrEmptyDomainDataException.CheckString(title, nameof(title));
			Cost = cost;
			Title = title;
		}

		public void Edit(int cost, string title)
		{
			NullOrEmptyDomainDataException.CheckString(title, nameof(title));
			Cost = cost;
			Title = title;
		}
		public string Title { get; private set; }
		public int Cost { get; private set; }
	}
}
