using GraphQL.Types;
using GraphQLSample.Core.Domains;

namespace GraphQLSample.Api.Models
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Field(book => book.Id);
            Field(book => book.Title);
            Field(book => book.Author);
        }
    }
}
