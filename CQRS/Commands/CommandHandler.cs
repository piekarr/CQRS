using CQRS.Results;
using System.Collections.Generic;

namespace CQRS
{
	public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
		where TCommand : ICommand
	{
		private readonly IEnumerable<IValidator<TCommand>> _validators;

		protected CommandHandler(IEnumerable<IValidator<TCommand>> validators)
		{
			_validators = validators;
		}

		public CommandResult Handle(TCommand command)
		{
			var validationResult = ValidateCommand(command);
			if (!validationResult.IsValid)
			{
				return validationResult.ToCommandResult();
			}
			return ExecuteCommand(command);
		}

		protected abstract CommandResult ExecuteCommand(TCommand command);

		private ValidationResult ValidateCommand(TCommand command)
		{
			foreach (var validator in _validators)
			{
				var result = validator.Validate(command);
				if (!result.IsValid)
				{
					return result;
				}
			}
			return ValidationResult.Success();
		}
	}
}
