namespace BitFinder.Search
{
    public class CompressedKeySearcher : KeySearcher
    {
        public override byte[] SearchPattern()
        {
            return new byte[]
            {
                0x30,
                0x81,
                0xD3,
                0x02,
                0x01,
                0x01,
                0x04,
                0x20
            };
        }

        protected override bool IsCompressed()
        {
            return true;
        }
    }
}