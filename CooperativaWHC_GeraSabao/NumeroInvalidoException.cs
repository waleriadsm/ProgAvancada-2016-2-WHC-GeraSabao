using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaWHC_GeraSabao
{
    class NumeroInvalidoException : System.Exception
    {
        public NumeroInvalidoException() : base() { }
        public NumeroInvalidoException(string message) : base(message) { }
        public NumeroInvalidoException(string message, System.Exception inner) : base(message, inner)
        {

            Console.WriteLine("Uma opção inválida foi digitada. Por favor, verifique o valor inserido e tente novamente.");
        }

    }
}