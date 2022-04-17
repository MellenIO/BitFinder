using BitFinder.Data;

namespace BitFinder.Search
{
    public interface IByteSearcher
    {
        Key[] SearchBytes(byte[] source, int length);
    }
}