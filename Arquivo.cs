using System;
using System.IO;

namespace ArquivosAspNet
{
    public class Arquivo
    {
        //criar arquivo usuario digitando o nome
        public string criarArquivo(string nome) {

            try
            {
                foreach (var letra in Path.GetInvalidFileNameChars()) //retirar caracter invalido
                {
                    nome = nome.Replace(letra, '_');
                }

                var path = Path.Combine(Environment.CurrentDirectory, $"{nome}.txt"); // caminho
                //File.Create(path); // Criar arquivo

                if (!File.Exists(path))
                {
                    using (var arquivo = File.CreateText(path))
                    {
                        arquivo.WriteLine("Arquivo criado pelo C# - aspNet");
                        arquivo.WriteLine("População: 15 milhões");
                        arquivo.WriteLine("IDH: 0.201");
                        arquivo.WriteLine("Dados: " + DateTime.Now);
                        arquivo.Flush();
                    }
                    return "Arquivo " + nome + " criado com sucesso!!!";
                }
                else
                {
                    return "Arquivo " + nome + " já existe criado!!!";
                }   
            }
            catch (Exception ex)
            {
                return "Erro ao criar arquivo " + ex.Message;
            }
        }
        // mover arquivo
        public string moverArquivo(string origem, string destino) {

            try
            {
                if (!File.Exists(destino))
                {
                    File.Move(origem, destino);
                    return "Arquivo foi movido para pasta!!!";
                }
                else
                {
                    return "Arquivo já existe na pasta!!!";
                }
            }
            catch (Exception ex)
            {
                return "Erro ao mover Arquivo ....." + ex.Message;
            }
        }
        // mover arquivo
        public string copiarArquivo(string origem, string destino)
        {

            try
            {
                if (!File.Exists(destino))
                {
                    File.Copy(origem, destino);
                    return "Arquivo foi copiado para pasta!!!";
                }
                else
                {
                    return "Arquivo não existe na origem!!!";
                }
            }
            catch (Exception ex)
            {
                return "Erro ao copiar Arquivo ....." + ex.Message;
            }
        }
    }
}
