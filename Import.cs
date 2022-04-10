using System;
using System.Collections.Generic;
using System.IO;

namespace ArquivosAspNet
{
    public class Import
    {
        //exeport
        public void exportCSV() {
            var path = Path.Combine(Environment.CurrentDirectory, "saida");

            var lista = new List<CID>() {
                new CID() {
                    Cod_CID = "A00",
                    Descricao = "A00   Colera"
                },
                new CID() {
                    Cod_CID = "A01",
                    Descricao = "A01   Febres tifoide e paratifoide"
                }
            };

            var di = new DirectoryInfo(path);
            if (!di.Exists)
            {
                di.Create();
                path = Path.Combine(path, "cid.csv");
            }

            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine("CID;Descricao");
                foreach (var item in lista)
                {
                    var linha = $"{item.Cod_CID};{item.Descricao}";
                    sw.WriteLine(linha);
                }
                sw.Flush();
            }
            
        }
        
        //import
        public void importarCSV() {
            var path = Path.Combine(Environment.CurrentDirectory,"import","cid.csv");
            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    var cabecalho = reader.ReadLine()?.Split(";");
                    while (true)
                    {
                        var registro = reader.ReadLine()?.Split(";");
                        if (registro == null) break;
                        for (int i = 0; i < registro.Length; i++)
                        {
                            Console.WriteLine($"{cabecalho?[i]}:{registro[i]}");
                            Console.WriteLine("------------------------------");
                        }
                        Console.WriteLine("\n\n");
                    }
                    Console.WriteLine("\n\nPressione o enter para finalizar");
                    //Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine($"O arquivo do {path} não Existe");
            }

        }
    }
}
