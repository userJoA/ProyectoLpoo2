using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace ClasesBase
{
    public static class TrabajarUsuarios
    {
        static readonly string connectionString = ClasesBase.Properties.Settings.Default.DBApp;

        
        //Traer Usuarios en una collection
        public static ObservableCollection<Usuario> TraerUsuario()
        {

            ObservableCollection<Usuario> listaUsuarios = new ObservableCollection<Usuario>();
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    string query = "SELECT u.Usu_ID, u.Usu_NombreUsuario, u.Usu_Contraseña, u.Usu_ApellidoNombre, " +
                                   "u.Rol_Codigo AS Usuario_Rol_Codigo, r.Rol_Codigo, r.Rol_Descripcion " +
                                   "FROM Usuario u " +
                                   "JOIN Roles r ON u.Rol_Codigo = r.Rol_Codigo;";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario
                            {

                                Usu_ID = reader.GetInt32("Usu_ID"),
                                Usu_Name = reader.GetString("Usu_NombreUsuario"),
                                Usu_Password = reader.GetString("Usu_Contraseña"),
                                Usu_FullName = reader.GetString("Usu_ApellidoNombre"),
                                Rol = new Roles
                                {
                                    Rol_Code = (int)reader["Rol_Codigo"],
                                    Rol_Description = (string)reader["Rol_Descripcion"]
                                }

                            };
                            // Obtener el valor de Usu_FullName desde la base de datos
                            string fullName = reader.GetString("Usu_ApellidoNombre");

                            // Dividir el nombre completo en apellido y nombre
                            string[] nameParts = fullName.Split(' ', 2); // El '2' limita el split a solo 2 partes

                            // Asignar el apellido y el nombre a Usu_LastName y Usu_NameO
                            usuario.Usu_LastName = nameParts.Length > 0 ? nameParts[0] : "";
                            usuario.Usu_NameO = nameParts.Length > 1 ? nameParts[1] : "";

                            listaUsuarios.Add(usuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al traer usuarios: " + ex.Message);
            }

            return listaUsuarios;
        }



        //Agregar usuario
        public static bool NuevoUsuario(Usuario usuario)
        {
            string query = @"
                INSERT INTO Usuario (Usu_NombreUsuario, Usu_Contraseña, Usu_ApellidoNombre, Rol_Codigo)
                VALUES (@NombreUsuario, @Contraseña, @ApellidoNombre, @RolCodigo)";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);

                // Asignación de parámetros
                cmd.Parameters.AddWithValue("@NombreUsuario", usuario.Usu_Name ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Contraseña", usuario.Usu_Password ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ApellidoNombre", usuario.Usu_FullName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@RolCodigo", usuario.Rol?.Rol_Code ?? (object)DBNull.Value);

                try
                {
                    cnn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al agregar usuario: " + ex.Message);
                    return false;
                }
            }
        }

        // Eliminar usuario por Id
        public static void deleteUsuario(int id)
        {
            string query = @"DELETE FROM Usuario WHERE Usu_ID = @IdUser";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@IdUser", id);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Actualizar usuario
        public static void updateUsuario(Usuario usuario)
        {
            string query = @"UPDATE Usuario 
                         SET Usu_NombreUsuario = @nUser, 
                             Usu_Contraseña = @pass, 
                             Usu_ApellidoNombre = @fullname, 
                             Rol_Codigo = @rol 
                         WHERE Usu_ID = @IdUser";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@nUser", usuario.Usu_Name);
                cmd.Parameters.AddWithValue("@pass", usuario.Usu_Password);
                cmd.Parameters.AddWithValue("@fullname", usuario.Usu_FullName);
                cmd.Parameters.AddWithValue("@rol", usuario.Rol.Rol_Code);
                cmd.Parameters.AddWithValue("@IdUser", usuario.Usu_ID);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //Traer Usuario
        public static Usuario? traerUsuarioPorID(int id)
        {
            Usuario? usuario = null;
            string query = @"
                        SELECT u.Usu_ID, u.Usu_NombreUsuario, u.Usu_Contraseña, u.Usu_ApellidoNombre, 
                        r.Rol_Codigo, r.Rol_Descripcion
                        FROM Usuario u
                        JOIN Roles r ON u.Rol_Codigo = r.Rol_Codigo
                        WHERE u.Usu_ID = @Id";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Id", id);

                cnn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = new Usuario
                        {
                            Usu_ID = reader.GetInt32(reader.GetOrdinal("Usu_ID")),
                            Usu_Name = reader.GetString(reader.GetOrdinal("Usu_NombreUsuario")),
                            Usu_Password = reader.GetString(reader.GetOrdinal("Usu_Contraseña")),
                            Usu_FullName = reader.GetString(reader.GetOrdinal("Usu_ApellidoNombre")),
                            Rol = new Roles
                            {
                                Rol_Code = (int)reader["Rol_Codigo"],
                                Rol_Description = (string)reader["Rol_Descripcion"]
                            }
                        };

                        // Obtener el valor de Usu_FullName desde la base de datos
                        string fullName = reader.GetString("Usu_ApellidoNombre");

                        // Dividir el nombre completo en apellido y nombre
                        string[] nameParts = fullName.Split(' ', 2); // El '2' limita el split a solo 2 partes

                        // Asignar el apellido y el nombre a Usu_LastName y Usu_NameO
                        usuario.Usu_LastName = nameParts.Length > 0 ? nameParts[0] : "";
                        usuario.Usu_NameO = nameParts.Length > 1 ? nameParts[1] : "";
                    }
                }
            }
            return usuario;
        }

    }
}
