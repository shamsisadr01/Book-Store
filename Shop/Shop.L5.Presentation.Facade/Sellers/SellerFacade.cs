using Common.L2.Application;
using MediatR;
using Shop.L2.Application.Sellers.Create;
using Shop.L2.Application.Sellers.Edit;
using Shop.L4.Query.Sellers.DTOs;
using Shop.L4.Query.Sellers.GetByFilter;
using Shop.L4.Query.Sellers.GetById;
using Shop.L4.Query.Sellers.GetByUserId;

namespace Shop.L5.Presentation.Facade.Sellers;

public class SellerFacade : ISellerFacade
{
	private readonly IMediator _mediator;
	public SellerFacade(IMediator mediator)
	{
		_mediator = mediator;
	}
	public async Task<OperationResult> CreateSeller(CreateSellerCommand command)
	{
		return await _mediator.Send(command);
	}
	public async Task<OperationResult> EditSeller(EditSellerCommand command)
	{
		return await _mediator.Send(command);
	}
	public async Task<SellerDto?> GetSellerById(long sellerId)
	{
		return await _mediator.Send(new GetSellerByIdQuery(sellerId));
	}

	public async Task<SellerDto?> GetSellerByUserId(long userId)
	{
		return await _mediator.Send(new GetSellerByUserIdQuery(userId));
	}

	public async Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams)
	{
		return await _mediator.Send(new GetSellerByFilterQuery(filterParams));
	}
}