using System;
using System.Collections.Generic;
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
    public class TokenController : ControllerBase
    {
        private readonly BainoBankApi _api;

        public TokenController(BainoBankApi api)
        {
            _api = api;
        }

        [HttpPost]
        public async Task<IActionResult> GetToken([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var retornoDto = await _api.GetTokenAsync(login);

            if (retornoDto.Sussesso)
                return Ok(retornoDto.Conteudo);

            return BadRequest(retornoDto);
        }
    }
}