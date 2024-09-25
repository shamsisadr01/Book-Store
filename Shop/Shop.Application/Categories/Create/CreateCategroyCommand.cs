using Common.L1.Domain.ValueObjects;
using Common.L2.Application;

namespace Shop.L2.Application.Categories.Create
{
	public record CreateCategroyCommand(string title, string slug, SeoData seoData) : IBaseCommand;
}
