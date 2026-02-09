using System.Security.Cryptography;

namespace DocType.Generic
{
    public class NanoId
    {
        public static string Generate(int size = 10, string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789")
        {

            int alphabetLength = alphabet.Length;


            using var rng = RandomNumberGenerator.Create();


            char[] id = new char[size];
            byte[] randomBytes = new byte[1];

            for (int i = 0; i < size; i++)
            {

                do
                {
                    rng.GetBytes(randomBytes);
                } while (randomBytes[0] >= alphabetLength * (256 / alphabetLength));


                id[i] = alphabet[randomBytes[0] % alphabetLength];
            }

            return new string(id);
        }
    }

}
