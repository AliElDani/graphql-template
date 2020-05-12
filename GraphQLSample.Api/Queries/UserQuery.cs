using GraphQL.Types;
using GraphQLSample.Api.Models;
using GraphQLSample.Core;
using GraphQLSample.Core.Domains;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GraphQLSample.Api.Queries
{
    public class UserQuery : ObjectGraphType
    {
        public UserQuery(IRepository repository)
        {
            Field<UserType>(
                "user",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => 
                    repository.Find<User>(u => u.Id == context.GetArgument("id", -1)).FirstOrDefault()
                    );

            Field<ListGraphType<UserType>>(
                "users",
                resolve: context => 
                    repository.GetAll<User>().Include(u=> u.Books));
        }
    }
}
