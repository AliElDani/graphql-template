using GraphQL.Types;
using System;

namespace GraphQLSample.Api.Models
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "UserInput";
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<StringGraphType>("email");
            Field<FloatGraphType>(
                "weightLbs",
                resolve: ctx => Convert.ToDecimal(ctx));
            Field<DateGraphType>("birthday");
            Field<ObjectGraphType>("books");
        }
    }
}
