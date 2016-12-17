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
        public static float produzirSabao(float saldoEstoqueInsumo, float qtdSabaoFeito, string strPathFile, GeradorDeSabao G, List<IGeraSabao> ListaGSabao)
        {
            saldoEstoqueInsumo = Arquivo.CarregaEstoqueInsumo(strPathFile + "EstoqueInsumo.txt");
            
            //Escolher um objeto para ser transformado em sabao.
            if(saldoEstoqueInsumo > 0)
            {
                Console.WriteLine("\nEscolha um objeto para ser transformado em Sabão. \n");

                float pesoUsado;
                float EstoqueSabao;
                int cont = 1;

                foreach (var x in ListaGSabao)
                {
                    string[] nome = x.ToString().Split('.');
                    Console.WriteLine(cont + " - " + nome[1] + " - " + x.Volume() + "Kg; ");                   
                    cont++;
                }
                

                Console.Write("\nDigite a referencia do item escolhido: ");
                int item = Convert.ToInt32(Console.ReadLine());

                qtdSabaoFeito = G.GeraSabao(ListaGSabao[item - 1]);

                pesoUsado = ListaGSabao[item - 1].Volume();

                saldoEstoqueInsumo = saldoEstoqueInsumo - pesoUsado;

                EstoqueSabao = Arquivo.CarregaEstoque(strPathFile + "EstoqueSabao.txt");

                EstoqueSabao = EstoqueSabao + qtdSabaoFeito;

                Arquivo.gerenciaEstoque((strPathFile + "EstoqueSabao.txt"), EstoqueSabao);

                Arquivo.CriaEstoqueInsumo((strPathFile + "EstoqueInsumo.txt"), saldoEstoqueInsumo);

                ListaGSabao.Remove(ListaGSabao[item - 1]);
            }else
            {
                Console.WriteLine("\nAtenção! Estoque de Insumos insuficiente para produzir sabão.");
                Console.WriteLine("Aguarde o novo recebimento.");

                Console.WriteLine("\nDigite qualquer tecla para prosseguir.");
                Console.ReadKey();
            }

            return qtdSabaoFeito;
            
        }

        //*************************************************************************************
        public static float venderSabao(float saldoEstoqueInsumo, float saldo, string strPathFile, List<Cliente> ListaClientes, string codigo, Cliente pessoa, int opcao, List<IGeraSabao> ListaGSabao, float peso, float qtdSabaoVender)
        {
            float renda = 0;
            saldo = Arquivo.CarregaEstoque(strPathFile + "EstoqueSabao.txt");

            if(saldo != 0)
            {
                Console.WriteLine("\nQuantidade de sabao em estoque: " + saldo);

                Console.Write("\nInforme o CPF/CNPJ do Cliente: ");
                codigo = Console.ReadLine();

                if (pessoa.ComparaCodigo(ListaClientes, codigo))
                {
                    Console.Write("\nQual a quantidade de sabão a ser vendida? ");
                    qtdSabaoVender = float.Parse(Console.ReadLine());


                    if (qtdSabaoVender <= saldo) //&& qtdSabaoVender != 0
                    {
                        Arquivo.CriaArquivoVenda((strPathFile + "ArquivoVenda.txt"), ListaClientes, qtdSabaoVender);
                        saldo = saldo - qtdSabaoVender;
                        Arquivo.gerenciaEstoque((strPathFile + "EstoqueSabao.txt"), saldo);
                        renda = qtdSabaoVender * 18.6f;
                        Console.WriteLine("\nValor a ser pago pelo Cliente: " + renda);

                        Console.WriteLine("\nDigite qualquer tecla para prosseguir.");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("\nAtenção! Estoque insuficiente para a realização da venda.");
                        Console.WriteLine("Produza mais sabão ou peça desculpas ao cliente.");

                        Console.WriteLine("\nDigite qualquer tecla para prosseguir.");
                        Console.ReadKey();
                    }

                }
                else
                {
                    Console.Write("\nCliente não encontrado. Verifique os dados informados e tente novamente. ");
                    Console.WriteLine("\nDigite qualquer tecla para prosseguir.");
                    Console.ReadKey();

                    Console.WriteLine("\nDeseja cadastrar o cliente? (Digite S para Sim ou N para Não)");
                    string querCadastrar = Console.ReadLine();
                    querCadastrar = querCadastrar.ToUpper();

                    if (querCadastrar == "S")
                    {
                        CadastrarCliente(saldoEstoqueInsumo, strPathFile, opcao, ListaGSabao, ListaClientes, peso);
                    }
                    else
                    {
                        Console.Clear();
                        Menus.Titulo();

                    }

                }
            }else
            {
                Console.WriteLine("\nAtenção! Estoque insuficiente para a realização da venda.");
                Console.WriteLine("Produza mais sabão ou peça desculpas ao cliente.");

                Console.WriteLine("\nDigite qualquer tecla para prosseguir.");
                Console.ReadKey();
            }
            return qtdSabaoVender;


        }        
    
    
        //*************************************************************************************


        public static void gerarRelatorio(string strPathFile, List<IGeraSabao> ListaGSabao, List<Cliente> ListaClientes, float qtdSabaoFeito, float qtdSabaoVender, float peso)
        {
            strPathFile = @"C:\Users\waler\Desktop\";
            //try
            //{ 

            
                GeraRelatorio.GeraRelatorioWHC(strPathFile + "WHC - RELATÓRIO_GERAL.txt", ListaClientes, qtdSabaoFeito, qtdSabaoVender, ListaGSabao, peso);


                Console.WriteLine("\nRelatório gerado com sucesso! ");
                Console.WriteLine("Procure e abra o arquivo 'WHC - RELATÓRIO_GERAL.txt' em sua área de trabalho.");

                Console.WriteLine("\nDigite qualquer tecla para prosseguir.");
                Console.ReadKey();

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("\nSeu relatório não pôde ser gerado.");
            //    Console.WriteLine("Digite qualquer tecla para prosseguir.");
            //    Console.ReadKey();
            //}
                        
        }

        //*************************************************************************************       


        public static void receberProduto(float saldoEstoqueInsumo, string strPathFile, Cliente pessoa, int opcao, List<IGeraSabao> ListaGSabao, List<Cliente> ListaClientes, float peso)
        {            
            
            Console.Write("\nCliente NOVO? (Digite S para sim ou N para não) ");
            string novo = Console.ReadLine();
            novo = novo.ToUpper();
            string codigo = "";            

            if (novo == "N")
            {
                Console.Write("\nInforme o CPF/CNPJ do Cliente (somente números): ");
                codigo = Console.ReadLine();

                if(pessoa.ComparaCodigo(ListaClientes, codigo))                       // acertar aqui
                {

                    for (int i = 0; i < ListaClientes.Count; i++)
                    {
                        if (codigo == ListaClientes[i].GetCodigo())
                        {                            
                            Console.WriteLine("Cliente: " + ListaClientes[i].GetNome());
                        }
                    }

                    Console.WriteLine("\nDigite qualquer tecla para prosseguir.");
                    Console.ReadKey();

                    Menus.MenuReceber(saldoEstoqueInsumo, strPathFile, opcao, ListaGSabao, peso, pessoa);
                    
                }
                else
                {                 
                        Console.Write("\nCliente não encontrado. Verifique os dados informados e tente novamente. ");
                        Console.WriteLine("\nDigite qualquer tecla para prosseguir.");
                        Console.ReadKey();
                        Console.Clear();
                        Menus.Titulo();                    
                        receberProduto(saldoEstoqueInsumo, strPathFile, pessoa, opcao, ListaGSabao, ListaClientes, peso);                   
                    
                }
            }
            else
            {

                if (pessoa.ComparaCodigo(ListaClientes, codigo))                       // acertar aqui
                {
                    Console.WriteLine("\nO CPF informado já pertence à outro cliente.");
                    Console.WriteLine("\nDigite qualquer tecla para prosseguir.");
                    Console.ReadKey();                                       

                }
                else
                {
                    CadastrarCliente(saldoEstoqueInsumo, strPathFile, opcao, ListaGSabao, ListaClientes, peso);
                    Menus.MenuReceber(saldoEstoqueInsumo, strPathFile, opcao, ListaGSabao, peso, pessoa);

                }

                
            }            
                       
                        
        }

        //*************************************************************************************

        
        public static List<Cliente> CadastrarCliente(float saldoEstoqueInsumo, string strPathFile, int opcao, List<IGeraSabao> ListaGSabao, List<Cliente> ListaClientes, float peso)
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
                            receberProduto(saldoEstoqueInsumo, strPathFile, pessoa, opcao, ListaGSabao, ListaClientes, peso);
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
                            receberProduto(saldoEstoqueInsumo, strPathFile, pessoa, opcao, ListaGSabao, ListaClientes, peso);
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
            float saldoEstoqueInsumo = 0;
            float qtdSabaoVender = 0;
            float qtdSabaoFeito = 0;

            List<IGeraSabao> ListaGSabao = new List<IGeraSabao>();

            List<Cliente> ListaClientes = new List<Cliente>();

            
            GeradorDeSabao G = new GeradorDeSabao();
            Cliente c = new PFisica("", "", "", "", "");

            CarregaDados.CarregaArquivo(ListaClientes);//, c
            CarregaDados.CarregaArquivoInsumo(ListaGSabao);
            //Console.ReadKey();
                        
            while (querFazer != 0) 
            {
                Console.Clear();
                Menus.Titulo();
                                
                string strPathFile = @"C:\Users\waler\Documents\Visual Studio 2015\Projects\CooperativaWHC_GeraSabao TESTE\RELATÓRIOS\";
                //string strPathFile2 = @"C:\Users\waler\Desktop\WHC - RELATÓRIO_GERAL_"+ DateTime.Today + ".txt";

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
                        Program.receberProduto(saldoEstoqueInsumo, strPathFile, c, opcao, ListaGSabao, ListaClientes, peso);

                    }
                    else
                    {
                        if (querFazer == 2)
                        {
                            qtdSabaoFeito = Program.produzirSabao(saldoEstoqueInsumo, qtdSabaoFeito, strPathFile, G, ListaGSabao);

                        }
                        else
                        {
                            if (querFazer == 3)
                            {
                                qtdSabaoVender = Program.venderSabao(saldoEstoqueInsumo, saldo, strPathFile, ListaClientes, codigo, c, opcao, ListaGSabao, peso, qtdSabaoVender);
                            }
                            else
                            {
                                if (querFazer == 4)
                                {
                                    Program.gerarRelatorio(strPathFile, ListaGSabao, ListaClientes, qtdSabaoFeito, qtdSabaoVender, peso);//alterar
                                }
                                else
                                {
                                    if (querFazer == 0)
                                    { querFazer = 0; }
                                    else
                                    {
                                        throw new NumeroInvalidoException("Uma opçao inválida foi digitada. Por Favor, escolha uma opçao válida.", null);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (NumeroInvalidoException ex)
                {
                    Console.WriteLine("\nUma opçao inválida foi digitada. Por Favor, escolha uma opçao válida e tente novamente.");
                    Console.WriteLine("Digite qualquer tecla para prosseguir.");
                    Console.ReadKey();
                }
            }
        }
                
    }
}
