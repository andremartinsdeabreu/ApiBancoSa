using Dominio.Enums;
using Dominio.Models.Interfaces;
using System;
using System.Threading.Tasks;

namespace Dominio.Models.Base
{
    public abstract class CreditoBase
    {
        private readonly ICredito _credito;
        public CreditoBase(ICredito credito)
        {
            _credito = credito;
        }

        protected ICredito Credito => _credito;

        public abstract Task<RetornoStatus> Calcular();

        protected virtual StatusCredito Validar()
        {
            StatusCredito status;
            int diaVencimento = (_credito.PrimeiroVencimento - DateTime.Now).Days;

            if (_credito.ValorCredito <= 1000000 &&
                (_credito.QuantidadeParcelas >= 5 && _credito.QuantidadeParcelas <= 72) &&
                (diaVencimento >= 15 && diaVencimento <= 40))
            {
                status = StatusCredito.Aprovado;
            }
            else
            {
                status = StatusCredito.Recusado;
            }

            return status;
        }
    }
}
