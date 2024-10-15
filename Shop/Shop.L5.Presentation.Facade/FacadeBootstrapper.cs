
using Microsoft.Extensions.DependencyInjection;
using Shop.L1.Domain.SiteEntities.Repositories;
using Shop.L5.Presentation.Facade.Categories;
using Shop.L5.Presentation.Facade.Comments;
using Shop.L5.Presentation.Facade.Orders;
using Shop.L5.Presentation.Facade.Products;
using Shop.L5.Presentation.Facade.Roles;
using Shop.L5.Presentation.Facade.Sellers.Inventories;
using Shop.L5.Presentation.Facade.Sellers;
using Shop.L5.Presentation.Facade.SiteEntities.Banner;
using Shop.L5.Presentation.Facade.SiteEntities.ShippingMethods;
using Shop.L5.Presentation.Facade.SiteEntities.Slider;
using Shop.L5.Presentation.Facade.Users.Addresses;
using Shop.L5.Presentation.Facade.Users;

namespace Shop.L5.Presentation.Facade
{
	public static class FacadeBootstrapper
	{
		public static void InitFacade(this IServiceCollection services)
		{
			services.AddScoped<ICategoryFacade, CategoryFacade>();
			services.AddScoped<ICommentFacade, CommentFacade>();
			services.AddScoped<IOrderFacade, OrderFacade>();
			services.AddScoped<IProductFacade, ProductFacade>();
			services.AddScoped<IRoleFacade, RoleFacade>();
			services.AddScoped<ISellerFacade, SellerFacade>();
			services.AddScoped<IBannerFacade, BannerFacade>();
			services.AddScoped<ISliderFacade, SliderFacade>();
			services.AddScoped<ISellerInventoryFacade, SellerInventoryFacade>();
			services.AddScoped<IShippingMethodFacade, ShippingMethodFacade>();

			services.AddScoped<IUserFacade, UserFacade>();
			services.AddScoped<IUserAddressFacade, UserAddressFacade>();
		}
	}
}
