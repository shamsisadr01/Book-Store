using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.L1.Domain.Order_Aggregate;
using Shop.L1.Domain.Order_Aggregate.ValeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L3.Infrastructure.Persistent.Ef.Order_Aggregate
{
	internal class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("Orders", "order");
			builder.OwnsOne(order => order.Discount, option =>
			{
				option.Property(orderDiscount => orderDiscount.DiscountTitle).HasMaxLength(50);
			});
			builder.OwnsOne(order => order.ShippingMethod, option =>
			{
				option.Property(shippingType => shippingType.ShippingType).HasMaxLength(50);
			});

			builder.OwnsMany(order => order.Items, option =>
			{
				option.ToTable("Items", "order");
			});

			builder.OwnsOne(b => b.Address, option =>
			{
				option.HasKey(b => b.Id);
				option.ToTable("Addresses", "order");

				option.Property(b => b.Shire)
					.IsRequired().HasMaxLength(100);

				option.Property(b => b.City)
					.IsRequired().HasMaxLength(100);

				option.Property(b => b.Name)
					.IsRequired().HasMaxLength(50);

				option.Property(b => b.Family)
					.IsRequired().HasMaxLength(50);

				option.Property(b => b.PhoneNumber)
					.IsRequired().HasMaxLength(12);

				option.Property(b => b.NationalCode)
					.IsRequired().HasMaxLength(10);

				option.Property(b => b.PostalCode)
					.IsRequired().HasMaxLength(20);
			});
		}
	}
}
