using CQRS.Results;

namespace CQRS
{
	public interface ICommandHandler<TCommand, TResult>
		where TCommand : ICommand<TResult>
	{
		CommandResult<TResult> Handle(TCommand command);
	}
}
