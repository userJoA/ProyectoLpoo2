using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase
{
    public class Evento
    {
        private static int NEXTID = 0;
        private int Eve_ID {  get; set; }
        public int Com_ID { get; set; }
        public int Atl_ID { get; set; }
        public string? Eve_Status { get; set; }
        public DateTime Eve_StartTime { get; set; }
        public DateTime Eve_EndTime { get; set; }

        public Evento() 
        {
            NEXTID++;
            this.Eve_ID = NEXTID;
        }

    }
}
