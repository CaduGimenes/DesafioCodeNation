using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioCodeNation.Classes;

namespace DesafioCodeNation
{
    class Program
    {
        static void Main(string[] args)
        {
            Api api = new Api();

            var result = api.getData();

            var crypto = new Cryptograph();

            result.decifrado = crypto.Decrypt(result.numero_casas, result.cifrado);
            result.resumo_criptografico = crypto.EncryptSHA1(result.decifrado);

            new JsonWriter(result);

            api.postData();

            Console.ReadLine();


        }
        
    }
}
