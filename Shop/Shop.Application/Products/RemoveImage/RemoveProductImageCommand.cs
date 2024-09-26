
using Common.L2.Application;

namespace Shop.L2.Application.Products.RemoveImage
{
	public record RemoveProductImageCommand(long ProductId, long ImageId) : IBaseCommand;
}
