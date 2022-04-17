using System.Security.Cryptography;

namespace BitFinder.Data
{
    public class Key
    {
        private byte[] _privateKey;
        private bool _compressed;

        public Key(byte[] privateKey, bool compressed)
        {
            _privateKey = privateKey;
            _compressed = compressed;
        }

        public string ToWIF(byte leading)
        {
            int extraBytes = _compressed ? 2 : 1;
            byte[] result = new byte[_privateKey.Length + extraBytes];
            result[0] = leading;
            for (int i = 0; i < _privateKey.Length; i++)
            {
                result[1 + i] = _privateKey[i];
            }

            if (_compressed)
            {
                result[^1] = 0x01;
            }

            byte[] hashed = Hash(result);

            byte[] final = new byte[result.Length + 4];
            for (int i = 0; i < result.Length; i++)
            {
                final[i] = result[i];
            }

            for (int i = 0; i < 4; i++)
            {
                final[result.Length + i] = hashed[i];
            }
            
            return Base58.Encode(final);
        }

        private byte[] Hash(byte[] data)
        {
            using (SHA256 sha = SHA256.Create())
            {
                var firstHash = sha.ComputeHash(data);
                return sha.ComputeHash(firstHash);
            }
        }
    }
}