using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaWHC_GeraSabao
{
    abstract class Produto : IGeraSabao
    {

        private float peso;
        private float volume;
        private string nome;


        public float Peso
        {
            get
            {
                return peso;
            }

            set
            {
                peso = value;
            }
        }

        public float Vol
        {
            get
            {
                return volume;
            }

            set
            {
                volume = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        //Contrutores
        public Produto(float peso, string nome)
        {
            this.Peso = peso;
            this.Nome = nome;

        }

        
        public float Volume()
        {
            float volume = this.peso;
            return volume;
        }

        public float GetPeso()
        {
            return peso;
        }

        public string GetNome()
        {
            return nome;
        }

        public abstract bool ComparaObjeto(List<IGeraSabao> ListaGSabao, IGeraSabao x, float peso);

    }
}
