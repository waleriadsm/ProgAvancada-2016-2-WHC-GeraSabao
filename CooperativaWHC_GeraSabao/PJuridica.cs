using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaWHC_GeraSabao
{
    class PJuridica : Cliente
    {
        private string cnpj;

        public string CNPJ
        {
            get
            {
                return cnpj;
            }

            set
            {
                cnpj = value;
            }
        }

        public PJuridica(string cnpj, string nome, string telefone, string email, string endereco) : base (nome, telefone, email, endereco)
        {
            this.CNPJ = cnpj;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
            this.Endereco = endereco;
        }

        public override string GetCodigo()
        {
            return CNPJ;
        }

        public override bool ComparaCodigo(List<Cliente> listaClientes, string codigo)
        {
            for (int i = 0; i < listaClientes.Count; i++)
            {
                if (codigo == listaClientes[i].GetCodigo())
                {
                    return true;
                }
            }
            return false;
        }


    }
}

