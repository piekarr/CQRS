using CQRS.Results;

namespace CQRS
{
	public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
		where TCommand : ICommand
	{
		private readonly ICQRSObjectValidator<TCommand> _validator;

		protected CommandHandler(ICQRSObjectValidator<TCommand> validator)
		{
			_validator = validator;
		}

		public CommandResult Handle(TCommand command)
		{
			var validationResult = _validator.ValidateObject(command);
			if (!validationResult.IsValid)
			{
				return validationResult.ToCommandResult();
			}
			return ExecuteCommand(command);
		}

		protected abstract CommandResult ExecuteCommand(TCommand command);
	}
}
