using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CooperativaWHC_GeraSabao
{
    static class Relatorio
    {

        public static void imprimeRelatorio()
        {
            string doc = @"C:/Users/waler/Documents/Visual Studio 2015/Projects/CooperativaWHC_GeraSabao TESTE/WHCRelatorio.txt";
            if (File.Exists(doc))
            {
                Stream entrada = File.Open(doc, FileMode.Open);                
                try
                {
                    using (StreamReader leitor = new StreamReader(entrada))
                    {
                        string linha = leitor.ReadLine();
                        // Lê linha por linha até o final do arquivo
                        while (linha != null)
                        {
                            Console.WriteLine(linha);
                            linha = leitor.ReadLine();
                        }
                        leitor.Close();
                        entrada.Close();
                    }                
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine(" O arquivo " + doc + "não foi localizado !");
            }
            Console.ReadKey();                        
        }

        public static void ProdutoCliente(string codigo, string x)
        {
            Stream arquivo = File.Open("WHCRelatorio.txt", FileMode.Create);
            StreamWriter escritor = new StreamWriter(arquivo);
            escritor.WriteLine(codigo+" "+x);
            escritor.Close();
            arquivo.Close();

        }

        public static void ClientesCadastrados(List<Cliente>ListaClientes)
        {
            Stream arquivo = File.Open("WHCRelatorio.txt", FileMode.Create);
            StreamWriter escritor = new StreamWriter(arquivo);
            escritor.WriteLine(ListaClientes);
            escritor.Close();
            arquivo.Close();

        }

        public static void ProdutosEstoque(List<IGeraSabao> ListaGSabao, float peso)
        {
            Stream arquivo = File.Open("WHCRelatorio.txt", FileMode.Create);
            StreamWriter escritor = new StreamWriter(arquivo);
            escritor.WriteLine(ListaGSabao+ " " + peso);
            escritor.Close();
            arquivo.Close();
        }

        public static void SabaoEstoque(float sabaoProduzido)
        {
            Stream arquivo = File.Open("WHCRelatorio.txt", FileMode.Create);
            StreamWriter escritor = new StreamWriter(arquivo);
            sabaoProduzido += sabaoProduzido;

            escritor.WriteLine("Sabão produzido: " + sabaoProduzido);
            escritor.Close();
            arquivo.Close();

        }


    }
}



