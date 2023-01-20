using AutoMapper;
using BancoSa.Models;
using Factory.AbstactFactory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BancoSa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditoController : ControllerBase
    {
        private readonly IMapper _mapper;

        public CreditoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// São passados como parâmetros os valores: 
        /// ValorCredito: Valor total solicitado para o crédito, 
        /// Tipo do Credito: 
        /// 1 >> Credito Direto, 
        /// 2 >> Credito Consignado, 
        /// 3 >> Credito Pessoa Jurídica, 
        /// 4 >> Credito Pessoa Física, 
        /// 5 >> Credito Imobiliário, 
        /// QuantidadeParcelas: Quantidade de Parcelas, 
        /// PrimeiroVencimento: Data do primeiro vencimento
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST
        ///     {
        ///         "valorCredito": 10000,
        ///         "tipoCredito": 1,
        ///         "quantidadeParcelas": 10,
        ///         "primeiroVencimento": "2022-06-10T20:20:21.199Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RetornaCredito([FromBody] CreditoRequest request)
        {
            try
            {
                var creditoFactory = CreditoAbstractFactory.CreateFactory(request);
                var retornoStatus = await creditoFactory.CriaCredito().Calcular();
                
                CreditoResponse creditoResponse = _mapper.Map<CreditoResponse>(retornoStatus);

                return Ok(creditoResponse);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
