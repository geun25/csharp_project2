using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunkListAnalysis
{
    public class Chunk
    {

        public Chunk(int ctype, int length, byte[] buffer)
        {
            CT = ctype;
            Length = length;
            Data = buffer;
        }

        public int CT // 청크 유형
        {
            get;
        }

        public int Length
        {
            get;
        }

        public byte[] Data
        {
            get;
        }

        public string CTString // 청크 유형 정수형 -> 문자열 변환
        {
            get
            {
                return StaticFuns.GetString(CT);
            }
        }

        public static Chunk Parse(Stream stream)
        {
            try
            {
                BinaryReader br = new BinaryReader(stream);
                int ctype = br.ReadInt32();
                int length = br.ReadInt32();
                length = StaticFuns.ConvertHostorder(length);
                byte[] buffer = br.ReadBytes(length);
                return new Chunk(ctype, length, buffer);
            }
            catch
            {
                return null;
            }
        }
    }
}
