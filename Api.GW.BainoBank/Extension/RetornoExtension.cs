using Api.GW.BainoBank.Interface;
using Api.GW.BainoBank.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api.GW.BainoBank.Extension
{
    public static class RetornoExtension
    {

        public static async Task<RetornoDto> ToRetornoDtoAsync(HttpResponseMessage response)
        {
            return new RetornoDto
            {
                Sussesso = response.IsSuccessStatusCode,
                Codigo = response.StatusCode,
                Status = response.ReasonPhrase,
                Conteudo = await response.Content.ReadAsStringAsync(),
                
            };
        }
    }
}
