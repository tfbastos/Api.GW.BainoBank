using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Api.GW.BainoBank.ClientsApi;
using Api.GW.BainoBank.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api.GW.BainoBank.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegociacaoController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly BainoBankApi _api;


        public NegociacaoController(IConfiguration Configuration, BainoBankApi api)
        {
            _configuration = Configuration;
            _api = api;
        }


        [HttpPost]
        public async Task<IActionResult> GetToken([FromQuery][Required] string token, [FromBody][Required] NegociacaoDto negociacao)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var value = ModelState.Values;  

            var retornoDto = await _api.NegociacaoAsync(token, negociacao);

            if (retornoDto.Sussesso)
                return Ok(retornoDto.Conteudo);

            return BadRequest(retornoDto);
        }


    }
}