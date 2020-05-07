using GraphQL;
using GraphQL.Types;
using GraphQLSample.Api.Mutations;
using GraphQLSample.Api.Queries;

namespace GraphQLSample.Api.Infrastructure
{
    public class MySchema : Schema
    {
        public MySchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<UserQuery>();
            Mutation = resolver.Resolve<UserMutation>();
        }
    }
}
