using CSharpFunctionalExtensions;

namespace PoohSticks.Common.Lib
{
    public class DomainObject<TEntity> where TEntity : Entity
    {
        private readonly TEntity _entity;
        protected DomainObject(TEntity entity)
        {
            _entity = entity;
        }

        public TEntity ApplyChange<TCommand>(TCommand cmd, Action<TCommand, TEntity> applyFn)
        {
            applyFn(cmd, _entity);
            return _entity;
        }

        public Result<TEntity> Apply<TCommand>(TCommand cmd)
        {
            if(this is IHandler<TCommand, TEntity> handler)
            {
                return handler.Handle(cmd);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
