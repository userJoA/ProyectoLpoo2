using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase
{
    internal class Evento
    {
        private int Eve_ID {  get; set; }
        private int Com_ID { get; set; }
        private int Atl_ID { get; set; }
        private string Eve_Status { get; set; }
        private DateTime Eve_StartTime { get; set; }
        private DateTime Eve_EndTime { get; set; }

        public Evento() { }

    }
}
