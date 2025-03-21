﻿

using Common.L1.Domain;
using Common.L1.Domain.Exceptions;
using Shop.L1.Domain.Seller_Aggregate.Enums;
using Shop.L1.Domain.Seller_Aggregate.Services;

namespace Shop.L1.Domain.Seller_Aggregate
{
	public class Seller : AggregateRoot
	{
		public long UserId { get; private set; }
		public string ShopName { get; private set; }
		public string NationalCode { get; private set; }
		public SellerStatus Status { get; private set; }
		public DateTime? LastUpdate { get; private set; }
		public List<SellerInventory> Inventories { get; private set; }

		private Seller()
		{
		}

		public Seller(long userId, string shopName, string nationalCode, ISellerDomainService domainService)
		{
			Guard(shopName, nationalCode);
			UserId = userId;
			ShopName = shopName;
			NationalCode = nationalCode;
			Inventories = new List<SellerInventory>();

			if (domainService.IsValidSellerInformation(this) == false)
				throw new InvalidDomainDataException("اطلاعات نامعتبر است");

		}

		public void AddInventory(SellerInventory inventory)
		{
			if (Inventories.Any(f => f.ProductId == inventory.ProductId))
				throw new InvalidDomainDataException("این محصول قبلا ثبت شده است.");

			Inventories.Add(inventory);
		}

		public void EditInventory(long inventoryId, int count, int price, int? discountPercentage)
		{
			var currentInventory = Inventories.FirstOrDefault(f => f.Id == inventoryId);
			if (currentInventory == null)
				throw new NullOrEmptyDomainDataException("محصول یافت نشد");

			//TODO Check Inventories
			currentInventory.Edit(count, price, discountPercentage);
		}

		public void ChangeStatus(SellerStatus status)
		{
			Status = status;
			LastUpdate = DateTime.Now;
		}

		public void Edit(string shopName, string nationalCode, SellerStatus status, ISellerDomainService domainService)
		{
			Guard(shopName, nationalCode);
			if (nationalCode != NationalCode)
				if (domainService.NationalCodeExistInDataBase(nationalCode))
					throw new InvalidDomainDataException("کدملی متعلق به شخص دیگری است");

			ShopName = shopName;
			NationalCode = nationalCode;
			Status = status;
		}

		private void Guard(string shopName, string nationalCode)
		{
			NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
			NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
			if (IranianNationalIdChecker.IsValid(nationalCode) == false)
				throw new InvalidDomainDataException("کد ملی نامعتبر است");
		}
	}
}
