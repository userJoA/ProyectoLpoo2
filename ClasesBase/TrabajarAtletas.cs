using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase
{
    public class TrabajarAtletas
    {
        public DataTable getAtlById(int atlId)
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.DBApp))
                {
                    string query = "SELECT * FROM Atleta WHERE Atl_ID = @AtlId";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@AtlId", atlId);
                        da.Fill(dt);
                    }
                }
                return dt;
            }
        }

        public void addAtl(Atleta oAtl)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.DBApp);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Atleta(Atl_Nombre,Atl_Apellido,Atl_DNI,Atl_Nacionalidad,Atl_Entrenador,Atl_Genero, Atl_Altura,Atl_Peso,Atl_FechaNac,Atl_Dirección,Atl_Email) values(@nom,@ape,@dni,@nac,@entrenador,@gen,@alt,@peso,@fnac,@dir,@email)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@nom", oAtl.Atl_Name);
            cmd.Parameters.AddWithValue("@ape", oAtl.Atl_LastName);
            cmd.Parameters.AddWithValue("@dni", oAtl.Atl_DNI);
            cmd.Parameters.AddWithValue("@nac", oAtl.Atl_Nationality);
            cmd.Parameters.AddWithValue("@entrenador", oAtl.Atl_Coach);
            cmd.Parameters.AddWithValue("@gen", oAtl.Atl_Gender);
            cmd.Parameters.AddWithValue("@alt", oAtl.Atl_Height);
            cmd.Parameters.AddWithValue("@peso", oAtl.Atl_Weight);
            cmd.Parameters.AddWithValue("@fnac", oAtl.Atl_BirthDate);
            cmd.Parameters.AddWithValue("@dir", oAtl.Atl_Address);
            cmd.Parameters.AddWithValue("@email", oAtl.Atl_Email);


            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void updateAtl(Atleta oAtl)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.DBApp);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Atleta SET Atl_Nombre = @nom, Atl_Apellido = @ape, Atl_DNI = @dni, Atl_Nacionalidad = @nac, Atl_Entrenador = @entrenador, Atl_Genero = @gen, Atl_Altura = @alt, Atl_Peso = @peso, Atl_FechaNac = @fnac, Atl_Dirección = @dir, Atl_Email = @email WHERE Atl_ID = @P_ID";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@nom", oAtl.Atl_Name);
            cmd.Parameters.AddWithValue("@ape", oAtl.Atl_LastName);
            cmd.Parameters.AddWithValue("@dni", oAtl.Atl_DNI);
            cmd.Parameters.AddWithValue("@nac", oAtl.Atl_Nationality);
            cmd.Parameters.AddWithValue("@entrenador", oAtl.Atl_Coach);
            cmd.Parameters.AddWithValue("@gen", oAtl.Atl_Gender);
            cmd.Parameters.AddWithValue("@alt", oAtl.Atl_Height);
            cmd.Parameters.AddWithValue("@peso", oAtl.Atl_Weight);
            cmd.Parameters.AddWithValue("@fnac", oAtl.Atl_BirthDate);
            cmd.Parameters.AddWithValue("@dir", oAtl.Atl_Address);
            cmd.Parameters.AddWithValue("@email", oAtl.Atl_Email);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void deleteAtl(int atlId)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.DBApp);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Atleta WHERE Atl_ID = @atlId";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@atlId", atlId);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
