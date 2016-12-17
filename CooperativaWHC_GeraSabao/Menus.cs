using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaWHC_GeraSabao
{
    class Menus
    {
        //*************************************************************************************

        public static void Titulo()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("\nBem vindo ao Sistema WHC GeraSabão!");
            Console.WriteLine("\n************************************");
            
        }

        //*************************************************************************************

        public static List<IGeraSabao> MenuReceber(float saldoEstoqueInsumo, string strPathFile, int opcao, List<IGeraSabao> ListaGSabao, float peso, Cliente pessoa)
        {               
            Console.Clear();
            Titulo();            
            float pesoi = 0;
            float aux;
                      

            while (opcao != 0)
            {
                Console.Clear();
                Console.WriteLine("\nQual o tipo de produto está recebendo?");
                Console.WriteLine("\n1 - Oleo");
                Console.WriteLine("2 - Abacate");
                Console.WriteLine("3 - Sebo");
                Console.WriteLine("0 - Para Voltar ao Menu Principal");

                Console.Write("\nDigite a Opção (1, 2, 3 ou 0): ");

                opcao = int.Parse(Console.ReadLine());

                try
                {
                    if (opcao == 1)
                    {
                        Console.Write("\nInforme o peso de Óleo recebido: ");
                        peso = float.Parse(Console.ReadLine());

                        saldoEstoqueInsumo = Arquivo.CarregaEstoqueInsumo(strPathFile + "EstoqueInsumo.txt");
                        aux = saldoEstoqueInsumo + peso;
                        Arquivo.CriaEstoqueInsumo(strPathFile + "EstoqueInsumo.txt", aux);

                        Oleo x = new Oleo(peso, "Oleo");                                              

                        if (x.ComparaObjeto(ListaGSabao, x, pesoi))
                        {
                            peso = peso + pesoi;
                            x = new Oleo(peso, "Oleo");
                            ListaGSabao.Add(x);
                            Console.ReadKey();
                        }
                        else
                        {
                            ListaGSabao.Add(x);
                        }                      
                    }
                    else
                    {
                        if (opcao == 2)
                        {
                            Console.Write("\nInforme o peso de Abacate recebido: ");
                            peso = float.Parse(Console.ReadLine());

                            saldoEstoqueInsumo = Arquivo.CarregaEstoqueInsumo(strPathFile + "EstoqueInsumo.txt");
                            aux = saldoEstoqueInsumo + peso;
                            Arquivo.CriaEstoqueInsumo(strPathFile + "EstoqueInsumo.txt", aux);

                            Abacate x = new Abacate(peso, "Abacate");
                            

                            if (x.ComparaObjeto(ListaGSabao, x, pesoi))
                            {
                                peso = peso + pesoi;
                                x = new Abacate(peso, "Abacate");
                                ListaGSabao.Add(x);
                                Console.ReadKey();
                            }
                            else
                            {
                                ListaGSabao.Add(x);
                            }
                                                       
                        }
                        else
                        {
                            if (opcao == 3)
                            {
                                Console.Write("\nInforme o peso de Sebo recebido: ");
                                peso = float.Parse(Console.ReadLine());

                                saldoEstoqueInsumo = Arquivo.CarregaEstoqueInsumo(strPathFile + "EstoqueInsumo.txt");
                                aux = saldoEstoqueInsumo + peso;
                                Arquivo.CriaEstoqueInsumo(strPathFile + "EstoqueInsumo.txt", aux);

                                Sebo x = new Sebo(peso, "Sebo");

                                if (x.ComparaObjeto(ListaGSabao, x, pesoi))
                                {
                                    peso = peso + pesoi;
                                    x = new Sebo(peso, "Sebo");
                                    ListaGSabao.Add(x);
                                    Console.ReadKey();
                                }
                                else
                                {
                                    ListaGSabao.Add(x);
                                }

                            }
                            else
                            {
                                if(opcao == 0)
                                {
                                    
                                }
                                else
                                {
                                    throw new NumeroInvalidoException("Uma opçao inválida foi digitada. Por Favor, escolha uma opçao válida e tente novamente1.", null);
                                }

                            }
                        }
                    }
                    
                                       

                }   // se for diferente de 1, 2, 3 ou 0
                catch (NumeroInvalidoException ex)
                {
                    Console.WriteLine("\nUma opçao inválida foi digitada. Por Favor, escolha uma opçao válida e tente novamente.");
                    Console.WriteLine("Digite qualquer tecla para prosseguir.");
                    Console.ReadKey();
                }

                
            }
            
            Arquivo.CriaInsumoRecebido(strPathFile + "InsumoRecebido.txt", ListaGSabao);
                        
            

            return ListaGSabao;            
        }

        //*************************************************************************************
    }
}
