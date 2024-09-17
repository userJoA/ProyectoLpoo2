using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase
{
    public class Competencia
    {
        private static int NEXTID = 0;
        private int Com_ID { get; set; }
        public string? Com_Name { get; set; }
        public string? Com_Description { get; set; }
        public DateTime Com_StarDate { get; set; }
        public DateTime Com_EndDate { get; set; }
        public string? Com_Status { get; set; }
        public string? Com_Organizer { get; set; }
        public string? Com_Location { get; set; }
        public string? Com_Sponsors { get; set; }
        public int Cat_ID { get; set; }
        public int Dis_ID { get;set; }

        public Competencia(int com_ID, string com_Name, string com_Description, DateTime com_StarDate, DateTime com_EndDate, string com_Status, string com_Organizer, string com_Location, string com_Sponsors, int cat_ID, int dis_ID)
        {
            Com_ID = com_ID;
            Com_Name = com_Name;
            Com_Description = com_Description;
            Com_StarDate = com_StarDate;
            Com_EndDate = com_EndDate;
            Com_Status = com_Status;
            Com_Organizer = com_Organizer;
            Com_Location = com_Location;
            Com_Sponsors = com_Sponsors;
            Cat_ID = cat_ID;
            Dis_ID = dis_ID;
        }

        public Competencia() 
        {
            NEXTID++;
            this.Com_ID = NEXTID;
        }
    }
}
