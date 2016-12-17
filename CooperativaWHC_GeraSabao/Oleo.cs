using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaWHC_GeraSabao
{
    class Oleo : Produto
    {
        public Oleo(float peso, string nome) : base(peso, nome)
        {
            this.Peso = peso;
            this.Nome = "Oleo";
        }



        public override bool ComparaObjeto(List<IGeraSabao> ListaGSabao, IGeraSabao x, float pesoi)
        {
            for (int i = 0; i < ListaGSabao.Count; i++)
            {
                if (x.GetNome() == ListaGSabao[i].GetNome())
                {
                    pesoi = ListaGSabao[i].GetPeso();
                    //return pesoi;
                    return true;
                }
            }
            return false;
        }
    }
}
