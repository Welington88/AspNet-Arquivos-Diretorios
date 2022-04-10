using System;
using System.IO;

namespace ArquivosAspNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //criar o diretorio
            Diretorio diretorio = new Diretorio();
            Console.WriteLine(diretorio.criarDiretorio());

            //criar arquivo
            /*Console.WriteLine("Digite o Nome do Arquivo: ");
            var nome = Console.ReadLine();*/
            
            Arquivo arquivo = new Arquivo();
            String nomeArquivo = "Brasil.txt";
            //retirar o .txt
            String nome = nomeArquivo.Substring(0, nomeArquivo.IndexOf("."));
            Console.WriteLine(arquivo.criarArquivo(nome));

            var origem  = Path.Combine(Environment.CurrentDirectory,nomeArquivo);
            var destino = Path.Combine(Environment.CurrentDirectory, "Globo", "América do Sul", nome , nomeArquivo);
            //Console.WriteLine(arquivo.copiarArquivo(origem,destino));
            Console.WriteLine(arquivo.moverArquivo(origem,destino));

            var buscar = Path.Combine(Environment.CurrentDirectory, "Globo");
            //diretorio.listarDiretorio(buscar);
            diretorio.listarArquivos(buscar);
            Console.WriteLine("Digite enter para finalizar!!!");

            Watcher watcher = new Watcher();
            watcher.monitorar(Environment.CurrentDirectory);

            Console.ReadKey();
        }
    }
}
