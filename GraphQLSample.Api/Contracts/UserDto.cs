using System;
using System.Collections.Generic;

namespace GraphQLSample.Api.Contracts
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email{ get; set; }
        public float WeightLbs { get; set; }
        public DateTime Birthday { get; set; }
        public IEnumerable<BookDto> Books { get; set; }
    }
}
