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

        //Contrutores
        public Produto(float peso)
        {
            this.Peso = peso;

        }

        public float Densidade()
        {
            float densidade = this.peso / this.volume;
            return densidade;
        }

        public float Volume()
        {
            float densidade = this.peso / this.volume;
            return densidade;
        }

    }
}
