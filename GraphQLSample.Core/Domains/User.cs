using System;
using System.Collections.Generic;

namespace GraphQLSample.Core.Domains
{
    public class User
    {
        private readonly List<Book> _books;

        public int Id { get; set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public float WeightLbs { get; private set; }

        public DateTime Birthday { get; private set; }

        public IEnumerable<Book> Books => _books.AsReadOnly();

        private User()
        {
            _books = new List<Book>();
        }

        public User(string firstName, string lastName, string email, float weightLbs, DateTime birthday) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            WeightLbs = weightLbs;
            Birthday = birthday;
        }

        public void BookRead(Book book)
        {
            _books.Add(book);
        }
    }
}
