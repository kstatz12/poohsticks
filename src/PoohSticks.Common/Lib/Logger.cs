using Microsoft.Extensions.Logging;

namespace PoohSticks.Common.Lib
{
    public class Logger
    {
        private readonly ILogger logger;
        private readonly ScopeBuilder scopeBuilder;

        public Logger(ILogger logger)
        {
            this.logger = logger;
            scopeBuilder = new ScopeBuilder();
        }

        public Logger WithScopes(Action<ScopeBuilder> k)
        {
            k(scopeBuilder);
            return this;
        }

        public void Execute(Action<ILogger> k)
        {
            using(this.logger.BeginScope(scopeBuilder.Build()))
            {
                k(this.logger);
            }
        }

        public T Execute<T>(Func<ILogger, T> k)
        {
            using(this.logger.BeginScope(scopeBuilder.Build()))
            {
                return k(this.logger);
            }
        }

        public async Task ExecuteAsync(Func<ILogger, Task> k)
        {
            using(this.logger.BeginScope(scopeBuilder.Build()))
            {
                await k(this.logger);
            }
        }

        public async Task<T> ExecuteAsync<T>(Func<ILogger, Task<T>> k)
        {
            using(this.logger.BeginScope(scopeBuilder.Build()))
            {
                return await k(this.logger);
            }
        }
    }
}
