using CQRS.Results;

namespace CQRS
{
	public abstract class CommandHandler<TCommand, TResult> : ICommandHandler<TCommand,TResult>
		where TCommand : ICommand<TResult>
	{
		private readonly ICQRSObjectValidator<TCommand> _validator;

		protected CommandHandler(ICQRSObjectValidator<TCommand> validator)
		{
			_validator = validator;
		}

		public CommandResult<TResult> Handle(TCommand command)
		{
			var validationResult = _validator.ValidateObject(command);
			if (!validationResult.IsValid)
			{
				return validationResult.ToCommandResult<TResult>();
			}
			return ExecuteCommand(command);
		}

		protected abstract CommandResult<TResult> ExecuteCommand(TCommand command);
	}
}
