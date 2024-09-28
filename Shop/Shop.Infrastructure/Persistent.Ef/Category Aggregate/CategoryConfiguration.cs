using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.L1.Domain.Category_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L3.Infrastructure.Persistent.Ef.Category_Aggregate
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Categories", "dbo");

			builder.HasKey(x => x.Id);
			builder.HasIndex(b => b.Slug).IsUnique();
			builder.Property(b => b.Slug).IsRequired().IsUnicode(false);
			builder.Property(b => b.Title).IsRequired();
			builder.HasMany(b => b.Childs).WithOne().HasForeignKey(b => b.ParentId);

			builder.OwnsOne(product => product.SeoData, config =>
			{
				config.Property(seoData => seoData.MetaDescription).HasColumnName("MetaDescription").HasMaxLength(500);
				config.Property(seoData=>seoData.MetaTitle).HasColumnName("MetaTitle").HasMaxLength(500);
				config.Property(seoData=>seoData.MetaKeyWords).HasColumnName("MetaKeyWords").HasMaxLength(500);
				config.Property(seoData=>seoData.IndexPage).HasColumnName("IndexPage");
				config.Property(seoData=>seoData.Canonical).HasColumnName("Canonical").HasMaxLength(500);
				config.Property(seoData=> seoData.Schema).HasColumnName("Schema");
			});
		}
	}
}
