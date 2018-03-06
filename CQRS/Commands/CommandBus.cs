namespace CQRS
{
	public class CommandBus : ICommandBus
	{
		private readonly ICommandHandlerFactory _commandHandlerFactory;

		public CommandBus(ICommandHandlerFactory commandHandlerFactory)
		{
			_commandHandlerFactory = commandHandlerFactory;
		}

		public void Execute<TCommand>(TCommand command)
			where TCommand : ICommand
		{
			var commandHandler = _commandHandlerFactory.Create<TCommand>();
			commandHandler.Handle(command);
		}
	}
}
