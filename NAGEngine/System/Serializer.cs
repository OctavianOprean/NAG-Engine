using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NAGEngine
{
    public static class Serializer
    {
        private static Dictionary<string, string> KeyWords;
        private static FileStream stream;
        private static StreamReader reader;
        private static string tmp;

        static Serializer()
        {
            stream = null;
            reader = null;
            tmp = null;
            KeyWords = new Dictionary<string, string>();
        }

        public static void ReadFile(string Path)
        {
            stream = new FileStream(Path, FileMode.Open);
            reader = new StreamReader(stream, Encoding.UTF8, true, 128);
            while (!reader.EndOfStream)
            {
                tmp = reader.ReadLine();
                KeyWords.Add(tmp.Split('=')[0], tmp.Split('=')[1]);
            }
            stream.Close();
        }
        public static int SerializeInt(string handler)
        {
            return Convert.ToInt32(KeyWords[handler]);
        }
        public static float SerializeFloat(string handler)
        {
            return Convert.ToSingle(KeyWords[handler]);
        }
        public static string SerializeString(string handler)
        {
            return Convert.ToString(KeyWords[handler]);
        }
        public static void ClearBuffer()
        {
            KeyWords.Clear();
        }
    }
}
