using System;

namespace Nac2Estoque.Exceptions
{
    public class ValidacaoException : Exception
    {
        public ValidacaoException(string mensagem) : base(mensagem) { }
    }
}
