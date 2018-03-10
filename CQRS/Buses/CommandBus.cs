using CQRS.Results;

namespace CQRS.Buses
{
	public class CommandBus : ICommandBus
	{
		private readonly ICommandHandlerFactory _commandHandlerFactory;

		public CommandBus(ICommandHandlerFactory commandHandlerFactory)
		{
			_commandHandlerFactory = commandHandlerFactory;
		}

		public CommandResult<TResult> Execute<TCommand, TResult>(TCommand command)
			where TCommand : ICommand<TResult>
		{
			var commandHandler = _commandHandlerFactory.Create<TCommand, TResult>();
			return commandHandler.Handle(command);
		}
	}
}
