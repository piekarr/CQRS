using CQRS.Queries;
using System;
using System.Collections.Generic;

namespace CQRS
{
	public class DefaultHandlerFactory : ICommandHandlerFactory, IQueryHandlerFactory
	{
		private static IDictionary<Type, Func<object>> _handlers = new Dictionary<Type, Func<object>>();

		CommandHandler<TCommand, TResult> ICommandHandlerFactory.Create<TCommand, TResult>()
		{
			return GetHandler<TCommand, CommandHandler<TCommand, TResult>>();
		}

		QueryHandler<TQuery, TResult> IQueryHandlerFactory.Create<TQuery, TResult>()
		{
			return GetHandler<TQuery, QueryHandler<TQuery, TResult>>();
		}

		public static void RegisterCommandHandler<TCommand, TResult>(Func<CommandHandler<TCommand, TResult>> commandHandlerFunc)
			where TCommand : ICommand<TResult>
		{
			_handlers.Add(typeof(TCommand), commandHandlerFunc);
		}

		public static void RegisterQueryHandler<TQuery, TResult>(Func<QueryHandler<TQuery, TResult>> queryHandlerFunc)
			where TQuery : IQuery<TResult>
		{
			_handlers.Add(typeof(TQuery), queryHandlerFunc);
		}

		private TResult GetHandler<TType, TResult>() where TResult : class
		{
			var handler = _handlers[typeof(TType)].Invoke();
			return handler as TResult;
		}
	}
}
