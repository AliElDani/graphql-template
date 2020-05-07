namespace GraphQLSample.Core
{
    public interface IUnitOfWork
    {
        IScope Begin();
    }
}
