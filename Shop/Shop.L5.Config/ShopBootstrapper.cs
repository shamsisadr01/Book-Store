using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Shop.L1.Domain.Category_Aggregate.Services;
using Shop.L1.Domain.Product_Aggregate.Services;
using Shop.L1.Domain.Seller_Aggregate.Services;
using Shop.L1.Domain.User_Aggregate.Services;
using Shop.L2.Application._Utilities;
using Shop.L2.Application.Categories;
using Shop.L2.Application.Categories.Create;
using Shop.L2.Application.Products;
using Shop.L2.Application.Sellers;
using Shop.L2.Application.Users;
using Shop.L3.Infrastructure;
using Shop.L4.Query.Categories.GetById;

namespace Shop.L6.Config
{
	public class ShopBootstrapper
	{
		public static void RegisterShopDependency(IServiceCollection service, string connectionString)
		{
			InfrastructureBootstrapper.Init(service, connectionString);

			service.AddMediatR(ctf =>
			ctf.RegisterServicesFromAssembly(typeof(CreateCategroyCommand).Assembly));

			service.AddMediatR(ctf =>
			ctf.RegisterServicesFromAssembly(typeof(GetCategoryByIdQuery).Assembly));

			service.AddTransient<ICategoryDomainService, CategoryDomainService>();
			service.AddTransient<IProductDomainService, ProductDomainService>();
			service.AddTransient<ISellerDomainService, SellerDomainService>();
			service.AddTransient<IUserDomainService, UserDomainService>();

			service.AddValidatorsFromAssembly(typeof(Directories).Assembly);
		}
	}
}
