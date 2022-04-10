using System;
using System.IO;

namespace ArquivosAspNet
{
    public class Diretorio
    {
        public string criarDiretorio() {
            var path = Path.Combine(Environment.CurrentDirectory, "globo"); //caminho

            if (!Directory.Exists(path))
            {
                try
                {
                    //criar diretorio
                    var dirGlobo = Directory.CreateDirectory(path);
                    var AmeNorte = dirGlobo.CreateSubdirectory("América do Norte");
                    var AmeCentral = dirGlobo.CreateSubdirectory("América do Central");
                    var AmeSul = dirGlobo.CreateSubdirectory("América do Sul");

                    AmeNorte.CreateSubdirectory("USA");
                    AmeNorte.CreateSubdirectory("Canada");
                    AmeNorte.CreateSubdirectory("Mexico");

                    AmeCentral.CreateSubdirectory("Panama");
                    AmeCentral.CreateSubdirectory("Costa Rica");

                    AmeSul.CreateSubdirectory("Brasil");
                    AmeSul.CreateSubdirectory("Argentina");
                    AmeSul.CreateSubdirectory("Uruguai");

                    return "Diretório criado com sucesso";
                }
                catch (Exception ex)
                {
                    return "Erro ao criar diretório " + ex;
                }
            }
            else
            {
                return "Diretório já existe";
            }
            
        }
        //lista de diretorios
        public void listarDiretorio(String path) {
            if (Directory.Exists(path))
            {
                var diretorios = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
                foreach (var dir in diretorios)
                {
                    var dirInfo = new DirectoryInfo(dir);
                    Console.WriteLine($"[Nome]:{dirInfo.Name}");
                    Console.WriteLine($"[Raiz]:{dirInfo.Root}");
                    if (dirInfo.Parent != null)
                    {
                        Console.WriteLine($"[Pai]:{dirInfo.Parent.Name}");
                    }
                    Console.WriteLine("--------------------------------------------------------");
                }
            }
        }
        //lista de arquivos
        public void listarArquivos(String path)
        {
            if (Directory.Exists(path))
            {
                var arquivos = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
                foreach (var arq in arquivos)
                {
                    var arqInfo = new FileInfo(arq);
                    Console.WriteLine($"[Nome]:{arqInfo.Name}");
                    Console.WriteLine($"[Tamanho]:{arqInfo.Length}");
                    Console.WriteLine("--------------------------------------------------------");
                }
            }
        }
    }
}
