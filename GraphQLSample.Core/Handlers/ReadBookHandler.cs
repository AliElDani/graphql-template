using GraphQLSample.Core.Commands;
using GraphQLSample.Core.Domains;
using MediatR;

namespace GraphQLSample.Core.Handlers
{
    public class ReadBookHandler : RequestHandler<ReadBook, User>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _uow;

        public ReadBookHandler(IRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        protected override User Handle(ReadBook request)
        {
            using (var scope = _uow.Begin())
            {
                var user = _repository.GetById<int, User>(request.UserId);
                if (user == null) return null;

                user.ReadBook(new Book(request.Title, request.Author));
                scope.Commit();
                return user;
            }
        }
    }
}
