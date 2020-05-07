using GraphQL.Types;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace GraphQLSample.Api.Infrastructure
{
    public static class ResolveFieldContextExtensions
    {
        public static TObject ConvertArgumentToObject<TObject>(this ResolveFieldContext ctx, string argumentName)
            => _convertArgument<TObject>(ctx.Arguments, argumentName);

        public static TObject ConvertArgumentToObject<TObject>(this ResolveFieldContext<object> ctx, string argumentName)
            => _convertArgument<TObject>(ctx.Arguments, argumentName);

        public static TObject ConvertArgumentToObject<TObject, TSource>(this ResolveFieldContext<TSource> ctx, string argumentName)
            => _convertArgument<TObject>(ctx.Arguments, argumentName);

        private static TObject _convertArgument<TObject>(IReadOnlyDictionary<string, object> arguments, string argumentName)
        {
            return arguments[argumentName] != null
                ? JToken.FromObject(arguments[argumentName]).ToObject<TObject>()
                : default;
        }
    }
}
