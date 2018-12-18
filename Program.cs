using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ProcuradorDeTelefones
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string diretorio = "C:/Users/marce/Desktop/telefones";
            //formato (99) 98888-8888
            string pattern = @"^\([1-9]{2}\) [1-9][0-9]{4}\-[0-9]{4}$";
            string [] arquivos = Directory.GetFiles(diretorio, "*.txt", SearchOption.TopDirectoryOnly);
            List<string> listaTelefones = new List<string>();

            Console.WriteLine($"Procurando no diretório {diretorio} arquivos que contenham telefones com formato (99) 98888-8888...");

            foreach (var nomearquivo in arquivos)
            {
                var nomeAbsoluto = Path.GetFileName(nomearquivo);
                var conteudo = File.ReadAllText(nomearquivo);

                Match match = Regex.Match(conteudo, pattern);

                if (match.Success)
                    listaTelefones.Add(nomeAbsoluto);
            }

            Console.WriteLine("Os seguintes arquivos possuem telefone no formato correto:");
            foreach (var nomearquivo in listaTelefones)
            {
                Console.WriteLine(nomearquivo);
            }

            Console.Read();
        }
    }
}
