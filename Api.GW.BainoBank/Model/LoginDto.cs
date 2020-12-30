using Api.GW.BainoBank.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Api.GW.BainoBank.Model
{
    public class LoginDto : IRequisicao
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
