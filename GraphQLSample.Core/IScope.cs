using System;

namespace GraphQLSample.Core
{
    public interface IScope : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
