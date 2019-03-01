using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VehicleTracker.Infrastructure.CacheManager
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
}
