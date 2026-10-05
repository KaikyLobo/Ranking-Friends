using System;

namespace RankingAmigos.Servicos
{
    public class RegraNegocioException : Exception
    {
        public RegraNegocioException(string mensagem)
            : base(mensagem)
        {
        }
    }
}