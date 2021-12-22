namespace PoohSticks.Common.Lib
{
    public class ScopeBuilder
    {
        private List<KeyValuePair<string, object>> scopes;

        public ScopeBuilder()
        {
            this.scopes = new List<KeyValuePair<string, object>>();
        }

        public ScopeBuilder WithValue(string name, object val)
        {
            this.scopes.Add(new KeyValuePair<string, object>(name, val));
            return this;
        }

        public List<KeyValuePair<string, object>> Build()
        {
            return this.scopes;
        }
    }
}
