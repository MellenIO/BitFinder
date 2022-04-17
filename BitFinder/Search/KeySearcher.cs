using System.Collections.Generic;
using BitFinder.Data;

namespace BitFinder.Search
{
    public abstract class KeySearcher : IByteSearcher
    {
        public abstract byte[] SearchPattern();

        protected abstract bool IsCompressed();

        public Key[] SearchBytes(byte[] source, int length)
        {
            byte[] pattern = SearchPattern();
            List<Key> keys = new List<Key>();
            int localIndex = 0;
            
            for (int i = 0; i < length; i++)
            {
                byte cur = source[i];

                //full match - extract key and move on 
                if (localIndex == pattern.Length - 1)
                {
                    keys.Add(ExtractKey(source, i + 1));
                    localIndex = 0;
                    i += 30; // skip a few bytes
                    continue;
                }

                if (cur != pattern[localIndex])
                {
                    localIndex = 0;
                }
                else
                {
                    localIndex++;
                }
            }

            return keys.ToArray();
        }

        protected Key ExtractKey(byte[] source, int offset)
        {
            byte[] key = new byte[32];
            for (int i = 0; i < key.Length; i++)
            {
                key[i] = source[offset + i];
            }

            return new Key(key, IsCompressed());
        }
    }
}