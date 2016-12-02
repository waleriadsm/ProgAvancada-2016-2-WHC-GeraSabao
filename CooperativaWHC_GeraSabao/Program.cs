using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CooperativaWHC_GeraSabao
{
    class Program
    {
        public static void produzirSabao(float qtdSabaoFeito, string strPathFile, GeradorDeSabao G, List<IGeraSabao> ListaGSabao)
        {
            //Escolher um objeto para ser transformado em sabao.
            Console.WriteLine("\nEscolha um objeto para ser transformado em Sabão. ");

            int cont = 1;
            foreach (var x in ListaGSabao)
            {
                string[] nome = x.ToString().Split('.');
                Console.WriteLine(cont + " - " + nome[1] + "; ");
                cont += cont;
            }

            Console.Write("\nDigite a referencia do item escolhido: ");
            int item = Convert.ToInt32(Console.ReadLine());

            qtdSabaoFeito = G.GeraSabao(ListaGSabao[item - 1]);

                       
            Arquivo.gerenciaEstoque((strPathFile + "estoque.txt"), qtdSabaoFeito);


            ListaGSabao.Remove(ListaGSabao[item - 1]);
        }

        //*************************************************************************************
        public static void venderSabao(float saldo, float qtdSabaoFeito, string strPathFile, List<Cliente> ListaClientes, string codigo, Cliente c, int opcao, List<IGeraSabao> ListaGSabao, float peso, float qtdSabaoVender)
        {            
            Arquivo.CarregaEstoque(strPathFile + "estoque.txt");

            Console.WriteLine("\nQuantidade de sabao em estoque: "+ qtdSabaoFeito);

            Console.Write("\nInforme o CPF/CNPJ do Cliente: ");
            codigo = Console.ReadLine();            

            if (c.ComparaCodigo(ListaClientes, codigo))                       // acertar aqui
            {
                Console.WriteLine("Cliente: ", c.Nome);

                Console.Write("\nQual a quantidade de sabão a ser vendida? ");
                qtdSabaoVender = float.Parse(Console.ReadLine());
                
                Arquivo.CriaArquivoVenda((strPathFile + "ArquivoVenda.txt"), ListaClientes, qtdSabaoVender);

                saldo = qtdSabaoFeito - qtdSabaoVender;

                Arquivo.gerenciaEstoque((strPathFile + "estoque.txt"), saldo);

            }
            else
            {
                Console.Write("\nCliente não encontrado. Verifique os dados informados: ");
                Console.ReadKey();
                Console.Clear();
                Menus.Titulo();
                
                receberProduto(strPathFile, c, opcao, ListaGSabao, ListaClientes, peso);
            }
            
        }
        
    
    
        //*************************************************************************************


        public static void gerarRelatorio(GeradorDeSabao G, List<IGeraSabao> ListaGSabao)
        {            
            //Indicar o valor em real de um conjunto de objetos(que podem ser de classes diferentes).
            Console.WriteLine("A quantidade total de Sabao produzido pelos itens recebidos é: ");
            G.TotalDeSabao(ListaGSabao);

            Console.WriteLine("\nO valor Total em Real em Sabao Produzido é: ");
            G.TotalDeObjeto(ListaGSabao, 18.6f);
        }

        //*************************************************************************************       


        public static void receberProduto(string strPathFile, Cliente c, int opcao, List<IGeraSabao> ListaGSabao, List<Cliente> ListaClientes, float peso)
        {            
            
            Console.Write("\nCliente NOVO? (Digite S para sim ou N para não) ");
            string novo = Console.ReadLine();
            novo = novo.ToUpper();
            string codigo = "";
            int encontrado = 0;

            if (novo == "N")
            {
                Console.Write("\nInforme o CPF/CNPJ do Cliente: ");
                codigo = Console.ReadLine();

                if(c.ComparaCodigo(ListaClientes, codigo))                       // acertar aqui
                {               
                
                    Menus.MenuReceber(opcao, ListaGSabao, peso);
                    Console.WriteLine(c.Nome);
                    encontrado = 1;
                    Console.ReadKey();
                }
                else
                {                 
                        Console.Write("\nCliente não encontrado. Verifique os dados informados: ");
                        Console.ReadKey();
                        Console.Clear();
                        Menus.Titulo();                    
                        receberProduto(strPathFile, c, opcao, ListaGSabao, ListaClientes, peso);                   
                    
                }
            }
            else
            {
                CadastrarCliente(strPathFile, c, opcao, ListaGSabao, ListaClientes, peso);
                Menus.MenuReceber(opcao, ListaGSabao, peso);
            }            
                       
                        
        }

        //*************************************************************************************

        
        public static List<Cliente> CadastrarCliente(string strPathFile, Cliente c, int opcao, List<IGeraSabao> ListaGSabao, List<Cliente> ListaClientes, float peso)
        {            

            Console.Clear();
            Menus.Titulo();           
                        
            Console.Write("\nO Cliente é Pessoa Fisica ou Juridica? (Digite F ou J) ");
            string TpPessoa = Console.ReadLine();
            TpPessoa = TpPessoa.ToUpper();            

            Console.WriteLine("\nDigite os dados do Cliente abaixo:");
            Console.Write("\nNome: ");
            string nome = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Endereco: ");
            string endereco = Console.ReadLine();

            Cliente pessoa;
            if (TpPessoa == "F")
            {
                Console.Write("CPF: ");
                string cpf = Console.ReadLine();
                pessoa = new PFisica(cpf, nome, telefone, email, endereco);
                while (pessoa.ComparaCodigo(ListaClientes, cpf))
                {
                    Console.Write("\nCPF já existente. Digite 1 para informar outro, ou digite 0 usar o cadastro existente: ");
                    int aCad = Convert.ToInt32(Console.ReadLine());
                    if (aCad == 1)
                    {
                        cpf = Console.ReadLine();
                        pessoa = new PFisica(cpf, nome, telefone, email, endereco);
                    }
                    else
                    {
                        if (aCad == 0)
                        {
                            receberProduto(strPathFile, c, opcao, ListaGSabao, ListaClientes, peso);
                        }
                    }

                }
            }
            else
            {
                Console.Write("CNPJ: ");
                string cnpj = Console.ReadLine();
                pessoa = new PJuridica(cnpj, nome, telefone, email, endereco);
                while (pessoa.ComparaCodigo(ListaClientes, cnpj))
                {
                    Console.Write("\nCNPJ já existente. Digite 1 para informar outro, ou digite 0 usar o cadastro existente: ");
                    int aCad = Convert.ToInt32(Console.ReadLine());
                    if (aCad == 1)
                    {
                        Console.WriteLine("");
                        cnpj = Console.ReadLine();
                        pessoa = new PJuridica(cnpj, nome, telefone, email, endereco);
                    }
                    else
                    {
                        if (aCad == 0)
                        {
                            receberProduto(strPathFile, c, opcao, ListaGSabao, ListaClientes, peso);
                        }
                    }
                }
            }
            ListaClientes.Add(pessoa);                      
                        
            Arquivo.CriarListaClientes((strPathFile + "ListadeClientes.txt"), ListaClientes);                        

            return ListaClientes;

        }



        //*****************************************************************************************************************************
        

        static void Main(string[] args)
        {
            int querFazer = 1;
            int opcao = 100;
            float peso = 0;
            string codigo = "";
            float saldo = 0;

            List<IGeraSabao> ListaGSabao = new List<IGeraSabao>();

            List<Cliente> ListaClientes = new List<Cliente>();

            //string strPathFile = @"C:/Users/waler/Documents/Visual Studio 2015/Projects/CooperativaWHC_GeraSabao TESTE/";
            //Arquivo.CarregarListaClientes((strPathFile + "ListadeClientes.txt"), ListaClientes);

            GeradorDeSabao G = new GeradorDeSabao();
            Cliente c = new PFisica("teste", "teste", "teste", "teste", "teste");

            
                        
            while (querFazer != 0) 
            {
                Console.Clear();
                Menus.Titulo();
                float qtdSabaoVender = 0;
                float qtdSabaoFeito = 0;

                string strPathFile = @"C:/Users/waler/Documents/Visual Studio 2015/Projects/CooperativaWHC_GeraSabao TESTE/";

                Console.WriteLine("\nO que você deseja fazer?");
                Console.WriteLine("\n1 - Receber um Produto"); //problema no cadastro do cliente - verificar se já esta cadastrado
                Console.WriteLine("2 - Produzir Sabão");
                Console.WriteLine("3 - Vender Sabão");
                Console.WriteLine("4 - Gerar Relatório");
                Console.WriteLine("0 - Sair");

                Console.Write("\nDigite a Opção (1, 2, 3, 4 ou 0): ");
                querFazer = int.Parse(Console.ReadLine());

                try
                {
                    if (querFazer == 1)
                    {
                        Program.receberProduto(strPathFile, c, opcao, ListaGSabao, ListaClientes, peso);

                    }
                    else
                    {
                        if (querFazer == 2)
                        {
                            Program.produzirSabao(qtdSabaoFeito, strPathFile, G, ListaGSabao);

                        }
                        else
                        {
                            if (querFazer == 3)
                            {
                                Program.venderSabao(saldo, qtdSabaoFeito, strPathFile, ListaClientes, codigo, c, opcao, ListaGSabao, peso, qtdSabaoVender);
                            }
                            else
                            {
                                if (querFazer == 4)
                                {
                                    Program.gerarRelatorio(G, ListaGSabao);
                                }
                                else
                                {
                                    if (querFazer == 0)
                                    { querFazer = 0; }
                                    else
                                    {
                                        throw new ArgumentException("Uma opçao inválida foi digitada. Por Favor, escolha uma opçao válida.");
                                    }
                                }
                            }
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("\nUma opção inválida foi digitada. Por favor, verifique o valor inserido e tente novamente.");
                    Console.ReadKey();
                }
            }
        }
                
    }
}
