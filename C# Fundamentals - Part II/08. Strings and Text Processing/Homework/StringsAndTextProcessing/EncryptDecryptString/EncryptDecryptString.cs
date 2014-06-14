namespace EncryptDecryptString
{
    using System;
    using System.Text;

    public class EncryptDecryptString
    {
        /// <summary>
        /// Write a program that encodes and decodes a string using given encryption key (cipher). The key consists of a sequence of characters. 
        /// The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key,        /// the second – with the second, etc. When the last key character is reached, the next is the first.
        /// </summary>
        public static void Main(string[] args)
        {
            string text = "This is some text that we will encrypt and decrypt.";
            Console.WriteLine(text);

            Console.WriteLine("Specify the Encryption Key:");
            string encryptionKey = Console.ReadLine();

            string encryptedText = EncryptString(text, encryptionKey);
            Console.WriteLine("The encrypted text:\n{0}", encryptedText);

            string decryptedText = DecryptString(encryptedText, encryptionKey);

            Console.WriteLine("The decrypted text:\n{0}", decryptedText);
        }

        public static string EncryptString(string text, string encryptionKey)
        {
            int j = 0;
            StringBuilder encryptedText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                encryptedText.Append(Convert.ToChar(text[i] ^ encryptionKey[j]));

                if (j == encryptionKey.Length - 1)
                {
                    j = 0;
                }
            }

            return encryptedText.ToString();
        }

        public static string DecryptString(string encryptedText, string encryptionKey)
        {
            int j = 0;
            StringBuilder decryptedText = new StringBuilder();

            for (int i = 0; i < encryptedText.Length; i++)
            {
                decryptedText.Append(Convert.ToChar(encryptedText[i] ^ encryptionKey[j]));

                if (j == encryptionKey.Length - 1)
                {
                    j = 0;
                }
            }

            return decryptedText.ToString();
        }
    }
}
