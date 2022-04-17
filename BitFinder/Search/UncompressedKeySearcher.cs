namespace BitFinder.Search
{
    public class UncompressedKeySearcher : KeySearcher
    {
        public override byte[] SearchPattern()
        {
            return new byte[]
            {
                0x30,
                0x82,
                0x01,
                0x13,
                0x02,
                0x01,
                0x01,
                0x40,
                0x20
            };
        }

        protected override bool IsCompressed()
        {
            return false;
        }
    }
}