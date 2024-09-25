using Common.Domain;
using Common.Domain.Exceptions;

namespace _1.Shop.Domain.Product_Aggregate
{
	public class ProductDetail : BaseEntity
	{
		public ProductDetail(string key, string value)
		{
			NullOrEmptyDomainDataException.CheckString(key, nameof(key));
			NullOrEmptyDomainDataException.CheckString(value, nameof(value));

			Key = key;
			Value = value;
		}

		public long ProductId { get; internal set; }

		public string Key { get; private set; }

        public string Value { get; private set; }
    }
}
