using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaWHC_GeraSabao
{
    class GeradorDeSabao
    {
        public float sabaoProduzido;
        public float TotalSabaoProduzido;
        public float ValorTotal;


        public float GeraSabao(IGeraSabao x)
        {
            if (x.Volume() > 15.0)
            {
                sabaoProduzido = x.Volume() * 1.0f;
            }
            else
            {
                if (x.Volume() > 9.0)
                {
                    sabaoProduzido = x.Volume() * 0.8f;
                }
                else
                {
                    if (x.Volume() > 5.0)
                    {
                        sabaoProduzido = x.Volume() * 0.6f;
                    }
                    else
                    {
                        if (x.Volume() > 1.0)
                        {
                            sabaoProduzido = x.Volume() * 0.4f;
                        }
                    }
                }
            }
                        
            string[] nome = x.ToString().Split('.');

            Console.WriteLine("\nO produto " + x.GetNome() + " gerou de sabao: " + sabaoProduzido +"kg");

            Console.WriteLine("\nDigite qualquer tecla para prosseguir.");
            Console.ReadKey();
            return sabaoProduzido;
        }               


    public float TotalDeSabao(List<IGeraSabao> Objetos)
        {
            foreach (var x in Objetos)
            {
                TotalSabaoProduzido += GeraSabao(x);
            }            
            
            Console.WriteLine("Os produtos geraram de sabao " + TotalSabaoProduzido + "kg");
            return TotalSabaoProduzido;
        }


        //Um método que recebe uma lista de objetos e retorne o valor total desses objetos considerando o valor do grama de ouro em real.
        public float TotalDeObjeto(List<IGeraSabao> Objetos, float VlrGrSabao)
        {
            Console.WriteLine("O valor Total de venda em Reais de Sabao produzido é de: ");
            return TotalDeSabao(Objetos) * VlrGrSabao;
        }


    }
}
