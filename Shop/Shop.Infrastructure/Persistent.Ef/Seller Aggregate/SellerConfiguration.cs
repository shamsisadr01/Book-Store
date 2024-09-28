using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.L1.Domain.Seller_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L3.Infrastructure.Persistent.Ef.Seller_Aggregate
{
	internal class SellerConfiguration : IEntityTypeConfiguration<Seller>
	{
		public void Configure(EntityTypeBuilder<Seller> builder)
		{
			builder.ToTable("Sellers", "seller");
			builder.HasIndex(b => b.NationalCode).IsUnique();

			builder.Property(b => b.NationalCode)
				.IsRequired();

			builder.Property(b => b.ShopName)
				.IsRequired();

			builder.OwnsMany(b => b.Inventories, option =>
			{
				option.ToTable("Inventories", "seller");
				option.HasKey(b => b.Id);
				option.HasIndex(b => b.ProductId);
				option.HasIndex(b => b.SellerId);

			});
		}
	}
}
