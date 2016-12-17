using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using Word = Microsoft.Office.Interop.Word;

namespace CooperativaWHC_GeraSabao
{
    class GeraRelatorio
    {
        public static void GeraRelatorioWHC(string strPathFile, List<Cliente> ListaClientes, float qtdSabaoFeito, float qtdSabaoVender, List<IGeraSabao> ListaGSabao, float peso)
        {
            using (FileStream fs = File.OpenWrite(strPathFile))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine("**************************************");
                    sw.WriteLine("\nSistema WHC GeraSabão!");
                    sw.WriteLine("\n************************************\n");

                    sw.WriteLine("\nClientes Cadastrados:");
                    foreach (var x in ListaClientes)
                    {
                        sw.WriteLine("\nNome: " + x.Nome);
                        sw.WriteLine("Telefone: " + x.Telefone);
                        sw.WriteLine("Email: " + x.Email);
                        sw.WriteLine("Endereço: " + x.Endereco);
                        sw.WriteLine("CPF/CNPJ: " + x.GetCodigo());
                        sw.WriteLine("");
                    }

                    sw.WriteLine("\n**************************************\n");

                    sw.WriteLine("\nQuantidadede sabão feito: " + qtdSabaoFeito);
                    

                    sw.WriteLine("\n**************************************\n");

                    sw.WriteLine("\nVendas realizadas: ");
                    //CriaArquivoVenda
                    foreach (var x in ListaClientes)
                    {
                        sw.WriteLine("\nNome: " + x.Nome);
                        sw.WriteLine("CPF/CNPJ: " + x.GetCodigo());
                        sw.WriteLine("Quantidade vendida: " + qtdSabaoVender);
                        sw.WriteLine("");
                    }

                    sw.WriteLine("\n**************************************\n");

                    sw.WriteLine("\nItens recebidos: ");
                    float pesoSebo = 0;
                    float pesoOleo = 0;
                    float pesoAbacate = 0;
                    string nmSebo = "Sebo";
                    string nmAbacate = "Abacate";
                    string nmOleo = "Oleo";

                    foreach (var x in ListaGSabao)
                    {
                        string[] nome = x.ToString().Split('.');
                        if (nome[1] == "Sebo")
                        {
                            pesoSebo = x.GetPeso();
                        }
                        else
                        {
                            if (nome[1] == "Abacate")
                            {
                                pesoAbacate = x.GetPeso();
                            }
                            else
                            {
                                if (nome[1] == "Oleo")
                                {
                                    pesoOleo = x.GetPeso();
                                }
                            }
                        }

                        //sw.WriteLine("");
                    }
                    sw.WriteLine("\nItem: " + nmAbacate + " - " + "Peso: " + pesoAbacate);
                    sw.WriteLine("Item: " + nmOleo + " - " + "Peso: " + pesoOleo);
                    sw.WriteLine("Item: " + nmSebo + " - " + "Peso: " + pesoSebo);
                    

                    //Arquivo.ItensRecebidos(strPathFile, ListaGSabao);



                    sw.WriteLine("\n**************************************");

                    sw.WriteLine("\nEstoque atual de sabão: " + (qtdSabaoFeito- qtdSabaoVender));

                    //CriaEstoqueSabao                    
                    //float estoqueAtual = Arquivo.CriaEstoqueSabao(strPathFile, peso);
                    //sw.WriteLine(estoqueAtual);

                    sw.WriteLine("\n**************************************");

                    sw.WriteLine("\nRenda gerada com a venda do Sabão: " + (qtdSabaoFeito*18.6f));

                    //CriaEstoqueSabao
                    //sw.WriteLine((qtdSabaoFeito - estoqueAtual) * 18.6f);


                    sw.Close();
                }


                fs.Close();

            }

            //public static void gerenciaEstoque(string strPathFile, float qtdSabaoFeito)
            //{
            //    using (FileStream fs = File.OpenWrite(strPathFile))
            //    {
            //        using (var sw = new StreamWriter(fs))
            //        {
            //            sw.WriteLine(qtdSabaoFeito);

            //            sw.Close();
            //        }
            //        fs.Close();
            //    }
            //}

        //    public static void CriaArquivoVenda(string strPathFile, List<Cliente> ListaClientes, float qtdSabaoVender)
        //{
        //    using (FileStream fs = File.OpenWrite(strPathFile))
        //    {
        //        using (var sw = new StreamWriter(fs))
        //        {
        //            foreach (var x in ListaClientes)
        //            {
        //                sw.WriteLine(x.Nome);
        //                sw.WriteLine(x.GetCodigo());
        //                sw.WriteLine(qtdSabaoVender);
        //                sw.WriteLine("");
        //            }

        //            sw.Close();
        //        }
        //        fs.Close();

        //    }
        //}


        //public static void CriaInsumoRecebido(string strPathFile, List<IGeraSabao> ListaGSabao)
        //{
        //    using (FileStream fs = File.OpenWrite(strPathFile))
        //    {
        //        using (var sw = new StreamWriter(fs))
        //        {

        //            foreach (var x in ListaGSabao)
        //            {
        //                string[] nome = x.ToString().Split('.');
        //                sw.WriteLine("Item: " + nome[1] + " - Peso: " + x.GetPeso() + "Kg.");
        //                //sw.WriteLine("");
        //            }

        //            sw.Close();
        //        }
        //        fs.Close();


        //    }
        //}


        //public static void CriaEstoqueSabao(string strPathFile, float peso)
        //{
        //    using (FileStream fs = File.OpenWrite(strPathFile))
        //    {
        //        using (var sw = new StreamWriter(fs))
        //        {
        //            sw.WriteLine(peso);

        //            sw.Close();
        //        }
        //        fs.Close();
        //    }
        //}
    }

    }
}
