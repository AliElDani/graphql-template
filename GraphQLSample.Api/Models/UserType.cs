using GraphQL.Types;
using GraphQLSample.Core.Domains;
using System.Linq;

namespace GraphQLSample.Api.Models
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(x => x.Id);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.Email);
            Field(x => x.WeightLbs);
            Field(x => x.Birthday);
            Field(x => x.Books, nullable: true, type:
                typeof(ListGraphType<BookType>)).Description("Books");
            Field<BookType>("book",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => context.Source.Books.FirstOrDefault(port => port.Id == context.GetArgument<int>("id")));
            Field<BookType>("books",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => context.Source.Books.ToList());
        }
    }
}
