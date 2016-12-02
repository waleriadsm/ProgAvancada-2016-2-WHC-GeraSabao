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

        public static string MenuReceber(int opcao, List<IGeraSabao> ListaGSabao, float peso)
        {
            Console.Clear();
            Titulo();
            string dados = "";
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

                        Oleo x = new Oleo(peso);
                        ListaGSabao.Add(x);
                        dados = "Oleo - " + peso + "Kg.";                       

                    }
                    else
                    {
                        if (opcao == 2)
                        {
                            Console.Write("\nInforme o peso de Abacate recebido: ");
                            peso = float.Parse(Console.ReadLine());

                            Abacate x = new Abacate(peso);
                            ListaGSabao.Add(x);
                            dados = "Abacate - " + peso + "Kg.";                            

                        }
                        else
                        {
                            if (opcao == 3)
                            {
                                Console.Write("\nInforme o peso de Sebo recebido: ");
                                peso = float.Parse(Console.ReadLine());

                                Sebo x = new Sebo(peso);
                                ListaGSabao.Add(x);
                                dados = "Sebo - " + peso + "Kg.";                                

                            }
                            else
                            {
                                if(opcao == 0)
                                {
                                    dados = "";
                                }
                                else
                                {
                                    throw new NumeroInvalidoException("Uma opçao inválida foi digitada. Por Favor, escolha uma opçao válida.");
                                }

                            }
                        }
                    }
                }   // se for diferente de 1, 2, 3 ou 0
                catch (NumeroInvalidoException ex)
                {
                    Console.WriteLine("\nUma opção inválida foi digitada. Por favor, verifique o valor inserido e tente novamente.");
                    Console.ReadKey();
                }
                
            }            
            return dados;            
        }

        //*************************************************************************************
    }
}
