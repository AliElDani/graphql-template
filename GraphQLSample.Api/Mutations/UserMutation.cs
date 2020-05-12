using GraphQL.Types;
using GraphQLSample.Api.Contracts;
using GraphQLSample.Api.Models;
using GraphQLSample.Core.Commands;
using MediatR;

namespace GraphQLSample.Api.Mutations
{
    public class UserMutation : ObjectGraphType
    {
        public UserMutation(IMediator mediator)
        {
            Field<UserType>(
              "createUser",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }
              ),
              resolve: context =>
              {
                  var dto = context.GetArgument<UserDto>("user");

                  return mediator.Send(new CreateUser(dto.FirstName, dto.LastName, dto.Email, dto.WeightLbs, dto.Birthday)).Result;
              });

            Field<UserType>(
              "readBook",
              arguments: new QueryArguments(
                new QueryArgument<IntGraphType> { Name = "id" },
                new QueryArgument<NonNullGraphType<BookInputType>> { Name = "book" }
              ),
              resolve: context =>
              {
                  var id = context.GetArgument("id", -1);
                  if (id == -1) return null;

                  var dto = context.GetArgument<BookDto>("book");
                  return mediator.Send(new ReadBook(id, dto.Title, dto.Author)).Result;
              });
        }
    }
}
