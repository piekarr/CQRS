namespace CQRS
{
	public interface ICommandBus
	{
		void Execute<TCommand>(TCommand command) where TCommand : ICommand;
	}
}