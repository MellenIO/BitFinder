using System;
using System.IO;
using BitFinder.Search;

namespace BitFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            IByteSearcher[] searchers = new IByteSearcher[]
            {
                new CompressedKeySearcher(),
                new UncompressedKeySearcher()
            };
            
            using (FileStream fs = new FileStream(@"E:\Backup Things\wallet.dat", FileMode.Open, FileAccess.Read))
            {
                //10mb at a time!
                byte[] chunk = new byte[10 * 1024 * 1024];
                long bytesToRead = fs.Length;
                while (bytesToRead > 0)
                {
                    int bytesRead = fs.Read(chunk);

                    if (bytesRead == 0) break;
                    //Console.WriteLine($"A chunk of {bytesRead} bytes has been read, searching...");
                    foreach (var searcher in searchers)
                    {
                        var foundKeys = searcher.SearchBytes(chunk, bytesRead);
                        if (foundKeys.Length > 0)
                        {
                            Console.WriteLine($"Found {foundKeys.Length} keys!");
                            foreach (var key in foundKeys)
                            {
                                Console.WriteLine($"WIF");
                                Console.WriteLine($"Bitcoin: {key.ToWIF(0x80)}");
                                Console.WriteLine($"Dogecoin: {key.ToWIF(0x9E)}");
                                Console.WriteLine($"");
                            }
                        }
                    }
                    // process
                    
                    bytesToRead -= bytesRead;
                }
            }
        }
    }
}