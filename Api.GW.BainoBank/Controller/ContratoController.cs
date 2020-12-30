using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.GW.BainoBank.ClientsApi;
using Api.GW.BainoBank.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api.GW.BainoBank.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly BainoBankApi _api;

        public ContratoController(IConfiguration Configuration, BainoBankApi api)
        {
            _configuration = Configuration;
            _api = api;
        }

        [HttpGet()]
        public async Task<IActionResult> GetContrato([FromQuery][Required] string token, [FromQuery][Required] string cpf)
        {
            var retornoDto = await _api.GetContratoAsync(token, cpf);

            if (retornoDto.Sussesso)
                return Ok( Newtonsoft.Json.JsonConvert.DeserializeObject(retornoDto.Conteudo));

            return BadRequest(retornoDto);
        }
    }
}