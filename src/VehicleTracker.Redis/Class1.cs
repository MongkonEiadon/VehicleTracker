using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using StackExchange.Redis;

namespace VehicleTracker.Redis
{
    public interface ICacheProvider
    {
        void Subscribe(string topic, Action<byte[]> callback);
        void Publish(string topic, byte[] message);
        Task<byte[]> GetBinary(string key, int dbIndex = 0);
        Task SetBinary(string key, byte[] value, TimeSpan? timeout = null, int dbIndex = 0);
        Task<string> Get(string key, int dbIndex = 0);
        Task Set(string key, string value, TimeSpan? timeout = null, int dbIndex = 0);
        Task<IEnumerable<string>> GetMembers(string key, int dbIndex = 0);
        Task SetMembers(string key, IEnumerable<string> values, int dbIndex = 0);
        Task<Dictionary<string, string>> GetHash(string key, int dbIndex = 0);
        Task SetHash(string key, IDictionary<string, string> value, int dbIndex = 0);
    }

    public class CacheManager : ICacheProvider, IDisposable
    {
        private const string _redisConnMSG = "redis cache connection is required.";
        private readonly string _redisConnectionStr;
        private ConnectionMultiplexer _redisConnection;
        public CacheManager(string redisConnectionStr)
        {
            _redisConnectionStr = redisConnectionStr ?? throw new ArgumentNullException(_redisConnMSG);
            _redisConnection = Redis;
        }

        private ConnectionMultiplexer Redis => null;
             //_redisConnection == null || !_redisConnection.IsConnected ?
             //   new Function(5)
             //       .Decorate(() =>
             //       {
             //           return ConnectionMultiplexer.Connect(_redisConnectionStr);
             //       }).Result : _redisConnection;

        public IDatabase CacheDB(int dbIndex = 0) =>

             //The object returned from GetDatabase is a cheap pass-thru object
             //Ref:https://stackexchange.github.io/StackExchange.Redis/Basics
             Redis?.GetDatabase(dbIndex);

        public void Subscribe(string topic, Action<byte[]> callback)
        {
            Redis.GetSubscriber().Subscribe(new RedisChannel(topic, RedisChannel.PatternMode.Auto), (channel, message) =>
            {
                callback(message);
            });
        }
        public void Publish(string topic, byte[] message)
        {
            Redis.GetSubscriber().Publish(new RedisChannel(topic, RedisChannel.PatternMode.Auto), message, CommandFlags.FireAndForget);
        }

        public async Task<byte[]> GetBinary(string key, int dbIndex = 0)
        {
            return await CacheDB(dbIndex).StringGetAsync(key, CommandFlags.HighPriority);
        }

        public async Task SetBinary(string key, byte[] value, TimeSpan? timeout = null, int dbIndex = 0)
        {
            await CacheDB(dbIndex).StringSetAsync(key, value, timeout, When.Always, CommandFlags.FireAndForget);
        }

        public async Task<string> Get(string key, int dbIndex = 0)
        {
            return await CacheDB(dbIndex).StringGetAsync(key, CommandFlags.HighPriority);
        }

        public async Task Set(string key, string value, TimeSpan? timeout = null, int dbIndex = 0)
        {
            await CacheDB(dbIndex).StringSetAsync(key, value, timeout, When.Always, CommandFlags.FireAndForget);
        }

        public async Task<IEnumerable<string>> GetMembers(string key, int dbIndex = 0)
        {
            return (Array.ConvertAll(await CacheDB(dbIndex).SetMembersAsync(key, CommandFlags.HighPriority), m => (string)m));
        }

        public async Task SetMembers(string key, IEnumerable<string> values, int dbIndex = 0)
        {
            await CacheDB(dbIndex).SetAddAsync(key, Array.ConvertAll(values?.ToArray(), m => (RedisValue)m), CommandFlags.FireAndForget);
        }
        public async Task<Dictionary<string, string>> GetHash(string key, int dbIndex = 0)
        {
            return (await CacheDB(dbIndex).HashGetAllAsync(key, CommandFlags.HighPriority))?.ToStringDictionary();
        }

        public async Task SetHash(string key, IDictionary<string, string> value, int dbIndex = 0)
        {
            var data = value.Select(d => new HashEntry(d.Key, d.Value));
            await CacheDB(dbIndex).HashSetAsync(key, data?.ToArray(), CommandFlags.FireAndForget);
        }

        public void Dispose()
        {
            if (_redisConnection != null && _redisConnection.IsConnected)
            {
                _redisConnection.GetSubscriber().UnsubscribeAll(CommandFlags.FireAndForget);
                _redisConnection.Close();
            }
        }
    }
}
