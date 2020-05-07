using GraphQLSample.Core.Domains;
using MediatR;

namespace GraphQLSample.Core.Commands
{
    public class ReadBook : IRequest<User>
    {
        public int UserId { get; }
        public string Title { get; }
        public string Author { get; }
        public ReadBook(int userId, string title, string author)
        {
            UserId = userId;
            Title = title;
            Author = author;
        }
    }
}
