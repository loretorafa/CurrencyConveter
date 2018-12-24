using CurrencyConverter.Domain.Interfaces;
using CurrencyConverter.Domain.Models.Requests;
using CurrencyConverter.Domain.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CurrencyConverter.Application.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {

        private readonly IExchangeService _service;

        public CurrencyController(IExchangeService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lists All Supported Currencies
        /// </summary>
        /// <returns>ListReponse</returns>
        // GET: v1/List
        [HttpGet("List")]
        [Produces("application/JSON")]
        [ProducesResponseType(200)]
        public ActionResult<ListResponse> List()
        {
            var response = _service.GetSupportedCurrencies();

            return Ok(response);
        }

        /// <summary>
        /// Gets Rates from a Currency to Another
        /// </summary>
        /// <remarks>
        /// Sample Parameters:
        ///
        ///    "From": "USD",
        ///    "To": "BRL",
        ///    "Amount": 1
        ///
        /// </remarks>
        /// <response code="200">If From and To parameters are supported</response>
        /// <response code="400">If From and To parameters are not supported</response> 
        // GET: v1/Rates
        [HttpGet("Rates")]
        [Produces("application/JSON")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<RatesResponse> Rates([FromQuery]RatesRequest request)
        {
            try
            {
                var response = _service.GetExchange(request);
                return Ok(response);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
