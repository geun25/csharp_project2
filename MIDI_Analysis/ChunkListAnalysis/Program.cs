using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunkListAnalysis
{
    class Program
    {
        static string fname = "example.mid";
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(fname, FileMode.Open);
            while(fs.Position < fs.Length)
            {
                Chunk chunk = Chunk.Parse(fs);
                if (chunk != null)
                    Console.WriteLine($"{chunk.CTString}:{chunk.Length}bytes");
            }
        }
    }
}
