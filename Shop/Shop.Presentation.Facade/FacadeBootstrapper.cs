
using Microsoft.Extensions.DependencyInjection;
using Shop.L5.Presentation.Facade.Categories;
using Shop.L5.Presentation.Facade.Comments;

namespace Shop.L5.Presentation.Facade
{
	public static class FacadeBootstrapper
	{
		public static void InitFacade(this IServiceCollection services)
		{
			services.AddScoped<ICategoryFacade, CategoryFacade>();
			services.AddScoped<ICommentFacade, CommentFacade>();
		}
	}
}
