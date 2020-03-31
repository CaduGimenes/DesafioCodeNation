using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCodeNation.Classes
{
    class JsonWriter
    {
       public JsonWriter(Answer answer)
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

            try
            {
                string file = JsonConvert.SerializeObject(answer);

                File.WriteAllText(path+"//answer.json", file);

            }
            catch(Exception e)
            {
                Console.WriteLine("Ocorreu um problema ao salvar o arquivo, tente novamente.");
            }

        }
    }
}
