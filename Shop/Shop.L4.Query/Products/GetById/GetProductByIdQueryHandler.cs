using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Products.DTOs;

namespace Shop.L4.Query.Products.GetById
{
	public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto?>
	{
		private readonly StoreContext _storeContext;

		public GetProductByIdQueryHandler(StoreContext storeContext)
		{
			_storeContext = storeContext;
		}

		public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
		{
			var product = await _storeContext.Products.FirstOrDefaultAsync(p=>p.Id == request.productId,cancellationToken);
			var model = product.Map();
			if (model == null)
				return null;
			await model.SetCategories(_storeContext);
			return model;
		}
	}
}
