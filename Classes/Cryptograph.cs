using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCodeNation.Classes
{
    class Cryptograph
    {
        private char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();
        private string DecryptedString { get; set; }
        public string Encrypt(int key, string text)
        {
            char[] lettersArray = text.ToCharArray();

            for (int i = 0; i < lettersArray.Length; i++)
            {
                int alphabetLetterIndex = Array.IndexOf(Alphabet, lettersArray[i]);

                if (alphabetLetterIndex > -1)
                {
                    int newAlphabetIndex = alphabetLetterIndex + key;

                    if (newAlphabetIndex >= Alphabet.Length)
                    {
                        newAlphabetIndex -= Alphabet.Length;
                    }

                    DecryptedString += lettersArray[i].ToString().Replace(lettersArray[i], Alphabet[newAlphabetIndex]);

                }
                else
                {
                    DecryptedString += lettersArray[i].ToString();
                }

            }

            return DecryptedString;


        }
        public string Decrypt(int key, string text)
        {

            char[] lettersArray = text.ToCharArray();

            for (int i = 0; i < lettersArray.Length; i++)
            {
                int alphabetLetterIndex = Array.IndexOf(Alphabet, lettersArray[i]);

                if (alphabetLetterIndex > -1)
                {
                    int newAlphabetIndex = alphabetLetterIndex - key;

                    if (newAlphabetIndex < 0)
                    {
                        newAlphabetIndex = Alphabet.Length + newAlphabetIndex;
                    }

                    DecryptedString += lettersArray[i].ToString().Replace(lettersArray[i], Alphabet[newAlphabetIndex]);

                }
                else
                {
                    DecryptedString += lettersArray[i].ToString();
                }

            }

            return DecryptedString;

        }

        public string EncryptSHA1(string value)
        {
            byte[] data = Encoding.ASCII.GetBytes(value);
            byte[] hashData = new SHA1Managed().ComputeHash(data);
            string hash = string.Empty;
            foreach (var b in hashData)
            {
                hash += b.ToString("X2");
            }

            return hash.ToLower();

        }


    }
}
