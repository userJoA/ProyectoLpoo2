using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace ClasesBase
{
    public class TrabajarRoles
    {
        static readonly string connectionString = ClasesBase.Properties.Settings.Default.DBApp;
        public ObservableCollection<Roles> TraerRoles()
        {
            ObservableCollection<Roles> listaRoles = new ObservableCollection<Roles>();
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    string query = "SELECT Rol_Codigo, Rol_Descripcion FROM Roles";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Roles rol = new Roles
                            {

                                Rol_Code = reader.GetInt32("Rol_Codigo"),
                                Rol_Description = reader.GetString("Rol_Descripcion"),
       
                            };

                            listaRoles.Add(rol);
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
            
            }
            return listaRoles;
        }
    }
}
