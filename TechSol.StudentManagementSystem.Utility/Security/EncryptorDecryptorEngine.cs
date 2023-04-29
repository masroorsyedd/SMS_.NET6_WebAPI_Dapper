using TechSol.StudentManagementSystem.Utility.Common;
using System.Security.Cryptography;
using System.Text;

namespace TechSol.StudentManagementSystem.Utility.Security
{
    public class EncryptorDecryptorEngine
    {

        public static string password = @"key1@3$5$7%7*@4%6&8gtcfr#F%R*T(G#N$F$J0o";
        public static string EncryptString(string stringToEncrypt)
        {
            //bool returnVal = false;
            string encryptedString = string.Empty;

            //string Passphrase = password;
            string Passphrase = password;

            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();


            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            try
            {

                // Step 4. Convert the input string to a byte[]
                byte[] DataToEncrypt = UTF8.GetBytes(stringToEncrypt);

                // Step 5. Attempt to encrypt the string
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);

                encryptedString = Convert.ToBase64String(Results);
                //returnVal = true;
            }
            catch (Exception)
            {
                //Sentry.SentrySdk.CaptureException(ex);
                //errMsg = "Can't Encrypt a string " + Ex.Message;
                //throw ex;
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return encryptedString.Replace("+", "---");

        }
        public static string DecryptString(string encryptedString)
        {

            //bool returnVal = false;
            string originalString = string.Empty;

            //string Passphrase = password;
            string Passphrase = password;
            encryptedString = encryptedString.Replace("---", "+");

            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            try
            {

                // Step 4. Convert the input string to a byte[]
                byte[] DataToDecrypt = Convert.FromBase64String(encryptedString);

                // Step 5. Attempt to decrypt the string

                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);

                // Step 6. Return the decrypted string in UTF8 format
                originalString = UTF8.GetString(Results);
                //returnVal = true;

            }
            catch (Exception ex)
            {
                //Sentry.SentrySdk.CaptureException(ex);
                //throw ex;
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }


            return originalString;
        }
        public static string CreateHash(string value, string salt, HashType hashType)
        {
            string hashString = string.Empty;
            if (!string.IsNullOrEmpty(value))
            {
                HashAlgorithm hashAlg = HashAlgorithm.Create(hashType.ToString());
                byte[] pwordData = Encoding.Default.GetBytes(salt + value);
                byte[] hash = hashAlg.ComputeHash(pwordData);
                hashString = Convert.ToBase64String(hash);
            }
            return hashString;
        }
    }

}
