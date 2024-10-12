
using Common.CacheHelper;
using Common.L2.Application;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Shop.L2.Application.Categories.AddChild;
using Shop.L2.Application.Categories.Create;
using Shop.L2.Application.Categories.Edit;
using Shop.L2.Application.Categories.Remove;
using Shop.L4.Query.Categories.DTOs;
using Shop.L4.Query.Categories.GetById;
using Shop.L4.Query.Categories.GetByParentId;
using Shop.L4.Query.Categories.GetList;

namespace Shop.L5.Presentation.Facade.Categories
{
	public class CategoryFacade : ICategoryFacade
	{
		private readonly IMediator _mediator;
		private readonly IDistributedCache _distributedCache;

		public CategoryFacade(IMediator mediator, IDistributedCache distributedCache)
        {
            _mediator = mediator;
            _distributedCache = distributedCache;
        }

		public async Task<OperationResult<long>> AddChild(AddChildCategoryCommand command)
		{
			return await _mediator.Send(command);
		}

		public async Task<OperationResult> Edit(EditCategoryCommand command)
		{
			return await _mediator.Send(command);
		}

		public async Task<OperationResult<long>> Create(CreateCategoryCommand command)
		{
			return await _mediator.Send(command);
		}

		public async Task<OperationResult> Remove(long categoryId)
		{
			return await _mediator.Send(new RemoveCategoryCommand(categoryId));
		}

		public async Task<CategoryDto> GetCategoryById(long id)
		{
			return await _mediator.Send(new GetCategoryByIdQuery(id));
		}

		public async Task<List<SubCategoryDto>> GetCategoriesByParentId(long parentId)
		{
			return await _mediator.Send(new GetCategoryByParentIdQuery(parentId));
		}

		public async Task<List<CategoryDto>> GetCategories()
        {
            return await _distributedCache.GetOrSet(CacheKeys.Categories, () =>
            {
                return _mediator.Send(new GetCategoryListQuery());
            });
        }
	}
}
