using System.Security.Cryptography;

namespace Core.Cryptography
{

    public class KeyPair
    {
        public KeyPair() { }
        public string Public { get; set; }
        public string Private { get; set; }
    }
}
