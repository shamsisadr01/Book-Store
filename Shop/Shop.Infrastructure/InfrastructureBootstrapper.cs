using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.L1.Domain.Category_Aggregate.Repository;
using Shop.L1.Domain.Comment_Aggregate.Repositories;
using Shop.L1.Domain.Order_Aggregate.Repositories;
using Shop.L1.Domain.Product_Aggregate.Repository;
using Shop.L1.Domain.Role_Aggregate.Repository;
using Shop.L1.Domain.Seller_Aggregate.Repository;
using Shop.L1.Domain.SiteEntities.Repositories;
using Shop.L1.Domain.User_Aggregate.Repository;
using Shop.L3.Infrastructure.Persistent.Dapper;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L3.Infrastructure.Persistent.Ef.Category_Aggregate;
using Shop.L3.Infrastructure.Persistent.Ef.Comment_Aggregate;
using Shop.L3.Infrastructure.Persistent.Ef.Order_Aggregate;
using Shop.L3.Infrastructure.Persistent.Ef.Product_Aggregate;
using Shop.L3.Infrastructure.Persistent.Ef.Role_Aggregate;
using Shop.L3.Infrastructure.Persistent.Ef.Seller_Aggregate;
using Shop.L3.Infrastructure.Persistent.Ef.SiteEntities.Repositories;
using Shop.L3.Infrastructure.Persistent.Ef.User_Aggregate;

namespace Shop.L3.Infrastructure
{
	public static class InfrastructureBootstrapper
	{
		public static void Init(this IServiceCollection services,string connectionString)
		{
			services.AddTransient<ICategoryRepository, CategoryRepository>();
			services.AddTransient<IOrderRepository, OrderRepository>();
			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddTransient<IRoleRepository, RoleRepository>();
			services.AddTransient<ISellerRepository, SellerRepository>();
			services.AddTransient<IBannerRepository, BannerRepository>();
			services.AddTransient<ISliderRepository, SliderRepository>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<ICommentRepository, CommentRepository>();
			services.AddTransient<IShippingMethodRepository, ShippingMethodRepository>();

			services.AddTransient(_=> new DapperContext(connectionString));
			services.AddDbContext<StoreContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});
		}
	}
}
