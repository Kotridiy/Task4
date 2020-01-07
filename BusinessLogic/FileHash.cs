using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLogic
{
    public static class FileHash
    {
        static readonly MD5 md5 = MD5.Create();

        public static byte[] GetFileHash(FileInfo info)
        {
            string str = info.Name + info.Length + info.LastWriteTime;
            byte[] inputBytes = Encoding.ASCII.GetBytes(str);
            return md5.ComputeHash(inputBytes);
        }
    }
}
