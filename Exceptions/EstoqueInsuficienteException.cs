using System;

namespace Nac2Estoque.Exceptions
{
    public class EstoqueInsuficienteException : Exception
    {
        public EstoqueInsuficienteException(string mensagem) : base(mensagem) { }
    }
}
