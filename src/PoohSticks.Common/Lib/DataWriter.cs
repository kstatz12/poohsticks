using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using NHibernate;

namespace PoohSticks.Common.Lib
{
    public class DataWriter
    {
        private readonly ILogger logger;
        private readonly ISessionFactory sessionFactory;

        public DataWriter(ILogger logger, ISessionFactory sessionFactory)
        {
            this.logger = logger;
            this.sessionFactory = sessionFactory;
        }

        public virtual async Task<Result> Execute<T>(ChangeSet<T> cs)
            where T : Entity
        {
            return await new Logger(logger).WithScopes(sb =>
            {
                sb.WithValue("EntityType", typeof(T).Name);
            })
            .ExecuteAsync(async l => {
                try
                {
                    using var session = this.sessionFactory.OpenSession();
                    using var tx = session.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    var r = await session.QueryOver<T>()
                        .Where(cs.Predicate)
                        .SingleOrDefaultAsync();

                    if(r == null)
                    {
                        if(cs.Init == null)
                        {
                            return Result.Failure("Could Not Find Entity");
                        }
                        r = cs.Init();
                    }
                    cs.Transform(r);
                    await session.SaveOrUpdateAsync(r);
                    await tx.CommitAsync();
                    return Result.Success();
                }
                catch(Exception ex)
                {
                    l.LogError(ex, "Could Not Save Entity");
                    return Result.Failure(ex.Message);
                }
            });
        }
    }
}
