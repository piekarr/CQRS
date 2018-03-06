namespace CQRS
{
	public interface ICommandHandlerFactory
	{
		CommandHandler<TCommand> Create<TCommand>()
			where TCommand : ICommand;
	}
}
