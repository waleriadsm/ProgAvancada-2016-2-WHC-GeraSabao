using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaWHC_GeraSabao
{
    abstract class Cliente
    {
        private string nome;
        private string telefone;
        private string email;
        private string endereco;

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

        public string Telefone
        {
            get
            {
                return telefone;
            }

            set
            {
                telefone = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Endereco
        {
            get
            {
                return endereco;
            }

            set
            {
                endereco = value;
            }
        }

        public Cliente(string nome, string telefone, string email, string endereco)
        {
            this.Nome= nome;
            this.Telefone = telefone;
            this.Email = email;
            this.Endereco = endereco;
        }

        public abstract string GetCodigo();

        public abstract bool ComparaCodigo(List<Cliente> ListaCliente, string codigo);
        

    }
}
