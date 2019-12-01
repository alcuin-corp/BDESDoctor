using System;
using System.Collections.Generic;
using System.Linq;

namespace Alcuin.BDES.Domain.Transcodification
{
    internal abstract class Transcoder<T>
    {
        private readonly Dictionary<string, T> mapper;
        private readonly Dictionary<T, string> allowedKeys;

        public Transcoder()
        {
            this.mapper = new Dictionary<string, T>();
            this.allowedKeys = new Dictionary<T, string>();
        }

        internal string[] AllowedKeys => this.allowedKeys.Values.ToArray();

        internal bool TryTranscode(string input, out T result)
        {
            return this.mapper.TryGetValue(input.ToLowerInvariant(), out result);
        }

        protected void Map(T value, string defaultKey, params string[] keys)
        {
            this.allowedKeys[value] = defaultKey;
            this.mapper[defaultKey.ToLowerInvariant()] = value;
            foreach (var key in keys)
            {
                this.mapper[key.ToLowerInvariant()] = value;
            }
        }
    }
}