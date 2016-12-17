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
                        sw.Write(x.Nome + ";");
                        sw.Write(x.Telefone + ";");
                        sw.Write(x.Email + ";");
                        sw.Write(x.Endereco + ";");
                        sw.WriteLine(x.GetCodigo() + ";");
                        //sw.WriteLine(";");
                    }

                    sw.Close();
                }
                fs.Close();
            }
        }

        
        public static float gerenciaEstoque(string strPathFile, float qtdSabaoFeito)
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
            return qtdSabaoFeito;
        }

        public static float CarregaEstoque(string strPathFile)
        {
            float qtdSabaoFeito = 0;
            string txt = "";
            if (File.Exists(strPathFile))
            {

                using (StreamReader reader = new StreamReader(strPathFile))
                {
                    txt = reader.ReadLine();
                    qtdSabaoFeito = float.Parse(txt);
                    //float qtdSabaoFeito = float.Parse(sr.ReadLine());

                }
            }
                return qtdSabaoFeito;
            
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
                        sw.WriteLine(";");
                    }

                    sw.Close();
                }
                fs.Close();

            }
        }



        public static void CriaInsumoRecebido(string strPathFile, List<IGeraSabao> ListaGSabao)
        {
            using (FileStream fs = File.OpenWrite(strPathFile))
            {
                using (var sw = new StreamWriter(fs))
                {

                    foreach (var x in ListaGSabao)
                    {
                        string[] nome = x.ToString().Split('.');
                        sw.WriteLine(nome[1] + ";" + x.GetPeso() + ";");                                                
                        //sw.WriteLine("");
                    }                                                          

                    sw.Close();
                }
                fs.Close();


            }
        }


        public static float CriaEstoqueSabao(string strPathFile, float pesoSabaoFeito)
        {
            using (FileStream fs = File.OpenWrite(strPathFile))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(pesoSabaoFeito);

                    sw.Close();
                }
                fs.Close();
            }
            return pesoSabaoFeito;
        }


        public static float CarregaEstoqueSabao(string strPathFile)
        {
            float estoqueSabao = 0;
            string txt = "";
            if (File.Exists(strPathFile))
            {

                using (StreamReader reader = new StreamReader(strPathFile))
                {
                    txt = reader.ReadLine();
                    estoqueSabao = float.Parse(txt);                    

                }
            }
            return estoqueSabao;

        }

        public static void CriaEstoqueInsumo(string strPathFile, float peso)
        {
            using (FileStream fs = File.OpenWrite(strPathFile))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(peso);

                    sw.Close();
                }
                fs.Close();
            }
        }

        public static float CarregaEstoqueInsumo(string strPathFile)
        {
            float estoqueInsumo = 0;
            string txt = "";
            if (File.Exists(strPathFile))
            {

                using (StreamReader reader = new StreamReader(strPathFile))
                {
                    txt = reader.ReadLine();
                    estoqueInsumo = float.Parse(txt);

                }
            }
            return estoqueInsumo;
        }

        //public static void ItensRecebidos(string strPathFile, List<IGeraSabao> ListaGSabao)
        //{
        //    float pesoSebo = 0;
        //    float pesoOleo = 0;
        //    float pesoAbacate = 0;
        //    string nmSebo = "Sebo";
        //    string nmAbacate = "Abacate";
        //    string nmOleo = "Oleo";

        //    using (FileStream fs = File.OpenWrite(strPathFile))
        //    {
        //        using (var sw = new StreamWriter(fs))
        //        {

        //            foreach (var x in ListaGSabao)
        //            {
        //                string[] nome = x.ToString().Split('.');
        //                if (nome[1] == "Sebo")
        //                {                            
        //                    pesoSebo = pesoSebo + x.GetPeso();
        //                }else
        //                {
        //                    if (nome[1] == "Abacate")
        //                    {
        //                        pesoAbacate = pesoAbacate + x.GetPeso();
        //                    }
        //                    else
        //                    {
        //                        if (nome[1] == "Oleo")
        //                        {
        //                            pesoOleo = pesoOleo + x.GetPeso();
        //                        }
        //                   }
        //                }
                        
        //                //sw.WriteLine("");
        //            }
        //            sw.WriteLine("Item: " + nmAbacate + "; " + "Peso: "+ pesoAbacate + ";");
        //            sw.WriteLine("Item: " + nmOleo + "; " + "Peso: " + pesoOleo + ";");
        //            sw.WriteLine("Item: " + nmSebo + "; " + "Peso: " + pesoSebo + ";");
        //            sw.Close();
        //        }
        //        fs.Close();


        //    }
        //}


    }



}
