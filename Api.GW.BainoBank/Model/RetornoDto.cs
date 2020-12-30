using Api.GW.BainoBank.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.GW.BainoBank.Model
{
    public class RetornoDto
    {
        public HttpStatusCode Codigo { get; set; }
        public string Status { get; set; }
        public bool Sussesso { get; set; }
        public string Conteudo { get; set; }
    }
}
