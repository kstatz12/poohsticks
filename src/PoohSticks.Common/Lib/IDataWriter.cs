using CSharpFunctionalExtensions;

namespace PoohSticks.Common.Lib
{
    public interface IDataWriter
    {
        Task<Result> Execute<T>(ChangeSet<T> cs) where T : Entity;
    }
}
