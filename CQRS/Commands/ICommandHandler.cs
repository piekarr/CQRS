using CQRS.Results;

namespace CQRS
{
	public interface ICommandHandler<TCommand>
		where TCommand : ICommand
	{
		CommandResult Handle(TCommand command);
	}
}
