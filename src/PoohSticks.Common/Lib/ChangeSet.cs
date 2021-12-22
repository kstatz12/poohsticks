using System.Linq.Expressions;


namespace PoohSticks.Common.Lib
{
    public class ChangeSet<T>
    {
        public ChangeSet(Expression<Func<T, bool>> predicate, Action<T> transform, Func<T>? init = null)
        {
            Predicate = predicate;
            Transform = transform;
            Init = init;
        }

        public Expression<Func<T, bool>> Predicate { get; }
        public Action<T> Transform { get; }
        public Func<T>? Init { get; }
    }
}
