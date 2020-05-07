using GraphQL.Types;

namespace GraphQLSample.Api.Models
{
    public class BookInputType : InputObjectGraphType
    {
        public BookInputType()
        {
            Name = "BookInput";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<StringGraphType>>("author");
        }
    }
}
