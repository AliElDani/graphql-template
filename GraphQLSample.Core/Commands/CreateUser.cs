using GraphQLSample.Core.Domains;
using MediatR;
using System;

namespace GraphQLSample.Core.Commands
{
    public class CreateUser : IRequest<User>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public float WeightLbs { get; }
        public DateTime Birthday { get; }
        public CreateUser(string firstName, string lastName, string email, float weightLbs, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            WeightLbs = weightLbs;
            Birthday = birthday;
        }
    }
}
