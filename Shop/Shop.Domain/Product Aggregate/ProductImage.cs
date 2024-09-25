using Common.Domain;
using Common.Domain.Exceptions;

namespace _1.Shop.Domain.Product_Aggregate
{
	public class ProductImage : BaseEntity
	{
		public ProductImage(string imageName, int sequence)
		{
			NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
			ImageName = imageName;
			Sequence = sequence;
		}

		public long ProductId { get; internal set; }
		public string ImageName { get; internal set; }

		public int Sequence { get; private set; }
	}
}
