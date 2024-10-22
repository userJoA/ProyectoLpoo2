using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClasesBase
{
    public class TrabajarCompetencias
    {
        public DataTable getCompetencies()
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.DBApp))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("Select * from Competencia", cn))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }

        }

    }
}
