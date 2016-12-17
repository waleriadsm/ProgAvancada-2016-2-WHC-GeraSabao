using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CooperativaWHC_GeraSabao
{
    static class CarregaDados
    {

        public static void CarregaArquivo(List<Cliente> ListaClientes)//, Cliente pessoa
        {
            if (File.Exists(@"C:\Users\waler\Documents\Visual Studio 2015\Projects\CooperativaWHC_GeraSabao TESTE\RELATÓRIOS\ListadeClientes.txt"))
            {
                string[] array = File.ReadAllLines(@"C:\Users\waler\Documents\Visual Studio 2015\Projects\CooperativaWHC_GeraSabao TESTE\RELATÓRIOS\ListadeClientes.txt");
                //pessoa = new PFisica();

                //percorro o array e para cada linha
                for (int i = 0; i < array.Length; i++)
                {

                    string[] auxiliar = array[i].Split(';');
                    if (auxiliar[4].Length == 11)
                    {
                        PFisica pessoa = new PFisica("", "", "", "", "");

                        pessoa.Nome = auxiliar[0];
                        pessoa.Telefone = auxiliar[1];
                        pessoa.Email = auxiliar[2];
                        pessoa.Endereco = auxiliar[3];
                        pessoa.Cpf = auxiliar[4];

                        ListaClientes.Add(pessoa);
                    }
                    else
                    {
                        PJuridica pessoa = new PJuridica("", "", "", "", "");
                        pessoa.Nome = auxiliar[0];
                        pessoa.Telefone = auxiliar[1];
                        pessoa.Email = auxiliar[2];
                        pessoa.Endereco = auxiliar[3];
                        pessoa.CNPJ = auxiliar[4];

                        ListaClientes.Add(pessoa);
                    }
                }
            }

            //verificar o resultado
            //valores recuparados pelo List<Cliente>
            //foreach (var item in ListaClientes)
            //{
            //    Console.WriteLine(@"Nome: {0}; Telefone: {1}; E-mail: {2}; Endereço: {3}; CPF/CNPJ: {4}", item.Nome, item.Telefone, item.Email, item.Endereco, item.GetCodigo);
            //    Console.WriteLine(@"----------------------------------------------------------");
            //}

            //Console.ReadKey();
        }


        public static void CarregaArquivoInsumo(List<IGeraSabao> ListaGSabao)
        {
            if (File.Exists(@"C:\Users\waler\Documents\Visual Studio 2015\Projects\CooperativaWHC_GeraSabao TESTE\RELATÓRIOS\ListadeClientes.txt"))
            {
                string[] array = File.ReadAllLines(@"C:\Users\waler\Documents\Visual Studio 2015\Projects\CooperativaWHC_GeraSabao TESTE\RELATÓRIOS\ListadeClientes.txt");

                //percorro o array e para cada linha
                for (int i = 0; i < array.Length; i++)
                {
                    string[] auxiliar = array[i].Split(';');
                    if (auxiliar[0] == "Sebo")
                    {
                        Produto x = new Sebo(0, "");
                        x.Nome = auxiliar[0];
                        x.Peso = float.Parse(auxiliar[1]);
                        ListaGSabao.Add(x);
                    }
                    else
                    {
                        if (auxiliar[0] == "Oleo")
                        {
                            Produto x = new Oleo(0, "");
                            x.Nome = auxiliar[0];
                            x.Peso = float.Parse(auxiliar[1]);
                            ListaGSabao.Add(x);
                        }
                        else
                        {
                            if (auxiliar[0] == "Abacate")
                            {
                                Produto x = new Abacate(0, "");
                                x.Nome = auxiliar[0];
                                x.Peso = float.Parse(auxiliar[1]);
                                ListaGSabao.Add(x);
                            }
                        }
                    }
                }
            }

            //verificar o resultado
            
            //Console.ReadKey();
        }        

    }

}



