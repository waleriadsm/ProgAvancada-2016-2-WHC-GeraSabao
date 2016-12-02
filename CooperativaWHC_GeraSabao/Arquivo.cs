using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaWHC_GeraSabao
{
    class Arquivo
    {

        public static void CriarListaClientes(string strPathFile, List<Cliente> ListaClientes)
        {
            using (FileStream fs = File.OpenWrite(strPathFile))
            {
                using (var sw = new StreamWriter(fs))
                {
                    foreach (var x in ListaClientes)
                    {
                        sw.WriteLine(x.Nome);
                        sw.WriteLine(x.Telefone);
                        sw.WriteLine(x.Email);
                        sw.WriteLine(x.Endereco);
                        sw.WriteLine(x.GetCodigo());
                        sw.WriteLine("");
                    }

                    sw.Close();
                }
                fs.Close();

            }
        }


        public static void gerenciaEstoque(string strPathFile, float qtdSabaoFeito)
        {
            using (FileStream fs = File.OpenWrite(strPathFile))
            {
                using (var sw = new StreamWriter(fs))
                {

                    sw.WriteLine(qtdSabaoFeito);


                    sw.Close();
                }
                fs.Close();


            }
        }

        public static void CarregaEstoque(string strPathFile)
        {
            using (FileStream fs = File.OpenRead(strPathFile))
            {
                using (var sr = new StreamReader(fs))
                {

                   float LerqtdSabao = float.Parse(sr.ReadLine());

                   sr.Close();
                }
                fs.Close();



            }
        }


        public static void CriaArquivoVenda(string strPathFile, List<Cliente> ListaClientes, float qtdSabaoVender)
        {
            using (FileStream fs = File.OpenWrite(strPathFile))
            {
                using (var sw = new StreamWriter(fs))
                {
                    foreach (var x in ListaClientes)
                    {
                        sw.WriteLine(x.Nome);                        
                        sw.WriteLine(x.GetCodigo());
                        sw.WriteLine(qtdSabaoVender);
                        sw.WriteLine("");
                    }

                    sw.Close();
                }
                fs.Close();

            }
        }


    }



}
