using Common.L1.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.L1.Domain.Product_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L3.Infrastructure.Persistent.Ef.Product_Aggregate
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("Products", "product");
			builder.HasIndex("Slug").IsUnique();

			builder.Property(product=>product.Title).IsRequired().HasMaxLength(50);
			builder.Property(product => product.Slug).IsRequired().IsUnicode(false);
			builder.Property(product => product.Description).IsRequired();
			builder.Property(product => product.ImageName).IsRequired().HasMaxLength(110);

			builder.OwnsOne(product => product.SeoData, config =>
			{
				config.Property(seoData => seoData.MetaDescription).HasColumnName("MetaDescription").HasMaxLength(500);
				config.Property(seoData=>seoData.MetaTitle).HasColumnName("MetaTitle").HasMaxLength(500);
				config.Property(seoData=>seoData.MetaKeyWords).HasColumnName("MetaKeyWords").HasMaxLength(500);
				config.Property(seoData=>seoData.IndexPage).HasColumnName("IndexPage");
				config.Property(seoData=>seoData.Canonical).HasColumnName("Canonical").HasMaxLength(500);
				config.Property(seoData=> seoData.Schema).HasColumnName("Schema");
			});

			builder.OwnsMany(product => product.Images, option =>
			{
				option.ToTable("Images", "product");
				option.Property(product => product.ImageName).IsRequired().HasMaxLength(100);
			});

			builder.OwnsMany(product => product.ProductDetails, option =>
			{
				option.ToTable("ProductDetails", "product");
				option.Property(productDetail => productDetail.Key).IsRequired().HasMaxLength(50);
				option.Property(productDetail => productDetail.Value).IsRequired().HasMaxLength(100);
			});
		}
	}
}
