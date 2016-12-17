using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaWHC_GeraSabao
{
    class Sebo : Produto
    {
        public Sebo(float peso, string nome) : base(peso, nome)
        {
            this.Peso = peso;
            this.Nome = "Sebo";
        }

        public override bool ComparaObjeto(List<IGeraSabao> ListaGSabao, IGeraSabao x, float pesoi)
        {
            for (int i = 0; i < ListaGSabao.Count; i++)
            {
                if (x == ListaGSabao[i])
                {
                    pesoi = ListaGSabao[i].GetPeso();
                    return true;
                }
            }
            return false;
        }
    }
}
