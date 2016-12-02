using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaWHC_GeraSabao
{
    class PFisica : Cliente
    {
        private string cpf;

        public string Cpf
        {
            get
            {
                return cpf;
            }

            set
            {
                cpf = value;
            }
        }

        public PFisica(string cpf, string nome, string telefone, string email, string endereco) : base(nome, telefone, email, endereco)
        {
            this.Cpf = cpf;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
            this.Endereco = endereco;
        }

        public override string GetCodigo()
        {
            return Cpf;
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
