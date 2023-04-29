using System.Security.Cryptography;

namespace TechSol.StudentManagementSystem.Utility.Security
{
    public sealed class Encryption
    {


        private const int saltSize = 16; // 128 bit 
        private const int keySize = 32; // 256 bit
        private const int iterations = 10000;

        public string Hash { get; private set; }
        public string Salt { get; private set; }

        public Encryption()
        {

        }



        public string Encrypt(string password)
        {
            using (Rfc2898DeriveBytes algorithm = new Rfc2898DeriveBytes(password, saltSize, iterations, HashAlgorithmName.SHA512))
            {
                Hash = Convert.ToBase64String(algorithm.GetBytes(keySize));
                Salt = Convert.ToBase64String(algorithm.Salt);

                return $"{Hash}";
            }
        }

        public bool Verify(string password, string hash, string salt)
        {
            using (Rfc2898DeriveBytes algorithm = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), iterations, HashAlgorithmName.SHA512))
            {
                byte[] keyToCheck = algorithm.GetBytes(keySize);

                byte[] key = Convert.FromBase64String(hash);
                bool verified = keyToCheck.SequenceEqual(key);

                return verified;
            }
        }
    }
}
