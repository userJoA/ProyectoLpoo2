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
        public static DataTable getAtlById(int atlId)
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
        public static Atleta? GetAtlById(int atlId)
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

                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                DataRow row = dt.Rows[0];
                return new Atleta
                {
                    Atl_ID = (int)row["Atl_ID"],
                    Atl_Name = row["Atl_Nombre"] != DBNull.Value ? row["Atl_Nombre"].ToString() : null,
                    Atl_LastName = row["Atl_Apellido"] != DBNull.Value ? row["Atl_Apellido"].ToString() : null,
                    Atl_DNI = (int)row["Atl_DNI"],
                    Atl_Email = row["Atl_Email"] != DBNull.Value ? row["Atl_Email"].ToString() : null,
                    Atl_Nationality = row["Atl_Nacionalidad"] != DBNull.Value ? row["Atl_Nacionalidad"].ToString() : null,
                    Atl_Coach = row["Atl_Entrenador"] != DBNull.Value ? row["Atl_Entrenador"].ToString() : null,
                    Atl_Gender = row["Atl_Genero"] != DBNull.Value ? row["Atl_Genero"].ToString() : null,
                    Atl_Height = (double)row["Atl_Altura"],
                    Atl_BirthDate = row["Atl_FechaNac"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row["Atl_FechaNac"]),
                    Atl_Weight = (double)row["Atl_Peso"],
                    Atl_Address = row["Atl_Dirección"] != DBNull.Value ? row["Atl_Dirección"].ToString() : null
                };
            }
        }




        public Atleta getAtl()
        {
            Atleta oatl = new Atleta();
            oatl.Atl_Name = "";
            oatl.Atl_LastName = string.Empty;
            oatl.Atl_DNI = 11111111;
            oatl.Atl_Height = 0;
            oatl.Atl_Weight = 0;

            return oatl;
        }
        public static void addAtl(Atleta oAtl)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.DBApp);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Atleta(Atl_Nombre,Atl_Apellido,Atl_DNI,Atl_Nacionalidad,Atl_Entrenador,Atl_Genero, Atl_Altura,Atl_Peso,Atl_FechaNac,Atl_Dirección,Atl_Email) values(@nom,@ape,@dni,@nac,@entrenador,@gen,@alt,@peso,@fnac,@dir,@email)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@nom", oAtl.Atl_Name);
            cmd.Parameters.AddWithValue("@ape", oAtl.Atl_LastName);
            cmd.Parameters.AddWithValue("@dni", oAtl.Atl_DNI);
            cmd.Parameters.AddWithValue("@nac", DBNull.Value);
            cmd.Parameters.AddWithValue("@entrenador", DBNull.Value);
            cmd.Parameters.AddWithValue("@gen", DBNull.Value);
            cmd.Parameters.AddWithValue("@alt", oAtl.Atl_Height);
            cmd.Parameters.AddWithValue("@peso", oAtl.Atl_Weight);
            cmd.Parameters.AddWithValue("@fnac", DBNull.Value);
            cmd.Parameters.AddWithValue("@dir", DBNull.Value);
            cmd.Parameters.AddWithValue("@email", DBNull.Value);


            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void updateAtl(Atleta oAtl)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.DBApp);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Atleta SET Atl_Nombre = @nom, Atl_Apellido = @ape, Atl_DNI = @dni, Atl_Nacionalidad = @nac, Atl_Entrenador = @entrenador, Atl_Genero = @gen, Atl_Altura = @alt, Atl_Peso = @peso, Atl_FechaNac = @fnac, Atl_Dirección = @dir, Atl_Email = @email WHERE Atl_ID = @P_ID";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@nom", oAtl.Atl_Name ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ape", oAtl.Atl_LastName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@dni", oAtl.Atl_DNI == 0 ? (object)DBNull.Value : oAtl.Atl_DNI);
            cmd.Parameters.AddWithValue("@nac", oAtl.Atl_Nationality ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@entrenador", oAtl.Atl_Coach ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@gen", oAtl.Atl_Gender ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@alt", oAtl.Atl_Height.HasValue ? oAtl.Atl_Height.Value : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@peso", oAtl.Atl_Weight.HasValue ? oAtl.Atl_Weight.Value : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@fnac", oAtl.Atl_BirthDate.HasValue ? oAtl.Atl_BirthDate.Value : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@dir", oAtl.Atl_Address ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@email", oAtl.Atl_Email ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@P_ID", oAtl.Atl_ID);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void deleteAtl(int atlId)
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
