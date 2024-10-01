

using Common.L1.Domain;
using Common.L1.Domain.Exceptions;

namespace Shop.L1.Domain.Product_Aggregate
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
