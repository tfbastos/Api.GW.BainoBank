using Api.GW.BainoBank.Extension;
using Api.GW.BainoBank.Interface;
using Api.GW.BainoBank.Model;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Api.GW.BainoBank.ClientsApi
{
    public class BainoBankApi
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;

        public BainoBankApi(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<RetornoDto> GetTokenAsync(LoginDto login)
        {
            var response = await _httpClient.PostAsJsonAsync(_configuration.GetSection(Path.TOKEN.ToString()).Value, login);
            response.EnsureSuccessStatusCode();

            return await RetornoExtension.ToRetornoDtoAsync(response);
        }

        public async Task<RetornoDto> GetContratoAsync(string token, string cpf)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(_configuration.GetSection(Path.CONTRATO.ToString()).Value);

            return await RetornoExtension.ToRetornoDtoAsync(response);

        }

        public async Task<RetornoDto> NegociacaoAsync(string token, NegociacaoDto negociacao)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync(_configuration.GetSection(Path.NEGOCIACAO.ToString()).Value, negociacao);
            response.EnsureSuccessStatusCode();

            return await RetornoExtension.ToRetornoDtoAsync(response);
        }
    }
}
