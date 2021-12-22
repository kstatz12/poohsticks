namespace PoohSticks.Common.Lib
{
    public class Entity
    {
        public virtual int Id { get; protected set; }
        public virtual long Key { get; set; }

        public Entity()
        {

        }

        public Entity(long key)
        {
            Key = key;
        }
    }
}
