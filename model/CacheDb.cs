using StackExchange.Redis;

namespace model
{
    public class CacheDbService
    {
        private static ConnectionMultiplexer redis;
        public CacheDbService(string host) //localhost || host.docker.internal
        {
            redis = redis ?? ConnectionMultiplexer.Connect(host);
        }

        public IDatabase Db => redis.GetDatabase();

        public string[] Values()=>Db.SetMembers("blog").ToStringArray();
        public void ClearValues()=>Db.KeyDelete("blog");

        public void AddValue(string value)=>Db.SetAdd("blog",value);

    }
}