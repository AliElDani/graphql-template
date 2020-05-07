using GraphQL.Types;

namespace GraphQLSample.Api.Queries
{
    public class GraphQueries : ObjectGraphType
    {
        public GraphQueries()
        {
            Name = "Query";
            Field<UserQuery>("users", resolve: context => new { });
        }
    }
}
