using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.L1.Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L3.Infrastructure.Persistent.Ef.SiteEntities
{
	internal class ShippingMethodConfiguration : IEntityTypeConfiguration<ShippingMethod>
	{
		public void Configure(EntityTypeBuilder<ShippingMethod> builder)
		{
			builder.Property(b => b.Title)
				.HasMaxLength(120).IsRequired();
		}
	}
}
