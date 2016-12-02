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
            if (x.Volume() > 3.0)
            {
                sabaoProduzido = x.Densidade() * 1.0f;
            }
            else
            {
                if (x.Volume() > 2.1)
                {
                    sabaoProduzido = x.Densidade() * 0.8f;
                }
                else
                {
                    if (x.Volume() > 1.1)
                    {
                        sabaoProduzido = x.Densidade() * 0.6f;
                    }
                    else
                    {
                        if (x.Volume() > 0.1)
                        {
                            sabaoProduzido = x.Densidade() * 0.4f;
                        }
                    }
                }
            }

            Console.WriteLine("O produto " + x + " gerou de sabao (em gramas): ");
            return sabaoProduzido;
        }


        public float TotalDeSabao(List<IGeraSabao> Objetos)
        {
            foreach (var x in Objetos)
            {
                TotalSabaoProduzido += GeraSabao(x);
            }            
            
            Console.WriteLine("Os produtos geraram de sabao(em gramas): ");
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
