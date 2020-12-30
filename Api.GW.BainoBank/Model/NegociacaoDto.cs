using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.GW.BainoBank.Model
{
    public class NegociacaoDto
    {
        public long Contrato { get; set; }
        public DateTime Data { get; set; }
        public List<ParcelaDto> Parcelas { get; set; }
    }
}
