
namespace Shop.L1.Domain.Seller_Aggregate.Services
{
	public interface ISellerDomainService
	{
		bool IsValidSellerInformation(Seller seller);

		bool NationalCodeExistInDataBase(string nationalCode);
	}
}
