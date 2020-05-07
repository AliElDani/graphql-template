using GraphQLSample.Core.Commands;
using GraphQLSample.Core.Domains;
using MediatR;

namespace GraphQLSample.Core.Handlers
{
    public class CreateUserHandler : RequestHandler<CreateUser, User>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _uow;

        public CreateUserHandler(IRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        protected override User Handle(CreateUser request)
        {

            var user = new User(request.FirstName, request.LastName, request.Email, request.WeightLbs, request.Birthday);
            using (var scope = _uow.Begin())
            {
                _repository.Add(user);
                scope.Commit();
                return user;
            }
        }
    }
}
