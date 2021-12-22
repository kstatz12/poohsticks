namespace PoohSticks.Common.Lib
{
    public interface IProcess<TIn, TOut>
    {
        TOut Process(TIn message);
    }

    public interface IProcessAsync<TIn, TOut>
    {
       Task<TOut> ProcessAsync(TIn message);
    }
}
