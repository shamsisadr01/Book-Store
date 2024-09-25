using MediatR;

namespace _2.Common.Application
{
	public interface IBaseCommandHandler<TCommand> : IRequestHandler<TCommand, OperationResult> where TCommand : IBaseCommand
	{
	}

	public interface IBaseCommandHandler<TCommand, TResponseData> : IRequestHandler<TCommand, OperationResult<TResponseData>> where TCommand : IBaseCommand<TResponseData>
	{
	}
}