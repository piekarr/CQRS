using CQRS.Results;

namespace CQRS
{
	public interface ICommandBus
	{
		CommandResult<TResult> Execute<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>;
	}
}