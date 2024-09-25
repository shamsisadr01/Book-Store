using MediatR;

namespace _2.Common.Application
{
	public interface IBaseCommand : IRequest<OperationResult>
	{
	}

	public interface IBaseCommand<TData> : IRequest<OperationResult<TData>>
	{
	}
}