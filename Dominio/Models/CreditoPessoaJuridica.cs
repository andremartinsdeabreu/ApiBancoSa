using Dominio.Enums;
using Dominio.Models.Base;
using Dominio.Models.Interfaces;
using System;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public sealed class CreditoPessoaJuridica : CreditoBase
    {
        public CreditoPessoaJuridica(ICredito credito) : base(credito)
        {

        }

        protected override StatusCredito Validar()
        {
            StatusCredito status = base.Validar();
            if (Credito.ValorCredito < 15000)
                status = StatusCredito.Recusado;

            return status;
        }
        public override async Task<RetornoStatus> Calcular()
        {
            RetornoStatus retornoStatus = null;
            await Task.Run(() =>
            {
                if (Validar() == StatusCredito.Aprovado)
                {
                    double valorTotal = Credito.ValorCredito;

                    for (int i = 0; i < Credito.QuantidadeParcelas; i++)
                    {
                        valorTotal += (valorTotal * 5 / 100);
                    }
                    double juros = valorTotal - Credito.ValorCredito;

                    retornoStatus = new() { Status = StatusCredito.Aprovado, ValorJuros = Math.Round(juros, 2), ValorTotal = Math.Round(valorTotal, 2) };
                }
                else
                {
                    retornoStatus = new RetornoStatus() { Status = StatusCredito.Recusado, ValorJuros = 0, ValorTotal = 0 };
                }
            });

            return retornoStatus;
        }
    }
}
