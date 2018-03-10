namespace CQRS
{
	public interface ICommandHandlerFactory
	{
		CommandHandler<TCommand, TResult> Create<TCommand, TResult>()
			where TCommand : ICommand<TResult>;
	}
}
