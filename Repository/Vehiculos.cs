using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;

namespace SistemaWebAppi.Repository
{
    public class Vehiculos
    {
        private string connectionString = "Server=svr-sql-ctezo.southcentralus.cloudapp.azure.com;Database=db_banco;User Id=usr_admin;Password=usrGuastaUMG!ng;TrustServerCertificate= True";
        public string placa { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int anio { get; set; }
        public string color { get; set; }
        public string tipo { get; set; }
        public string estado { get; set; }

        // Metodo para guardar vehiculos
        public string GuardarVehiculo(Vehiculos vehiculos)
        {
            string qury = @"
                INSERT INTO vehiculos(placa, marca, modelo, anio, color, tipo, estado)
                VALUES (@placa, @marca, @modelo, @anio, @color, @tipo, @estado)
            ";
            try
            {
                //importante, cargar conector SQL
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(qury, con))
                    {
                        cmd.Parameters.AddWithValue("@placa", vehiculos.placa);
                        cmd.Parameters.AddWithValue("@marca", vehiculos.marca);
                        cmd.Parameters.AddWithValue("@modelo", vehiculos.modelo);
                        cmd.Parameters.AddWithValue("@anio", vehiculos.anio);
                        cmd.Parameters.AddWithValue("@color", vehiculos.color);
                        cmd.Parameters.AddWithValue("@tipo", vehiculos.tipo);
                        cmd.Parameters.AddWithValue("@estado", vehiculos.estado);
                        cmd.ExecuteNonQuery();
                    }
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        // Metodo para listar vehiculos
        public List<Vehiculos> ListarVehiculos()
        {
            List<Vehiculos> lista = new List<Vehiculos>();
            string qury = @"
                SELECT placa, marca, modelo, anio, color, tipo, estado
                FROM vehiculos
            ";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(qury, con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Vehiculos vehiculos = new Vehiculos();
                                vehiculos.placa = dr["placa"].ToString();
                                vehiculos.marca = dr["marca"].ToString();
                                vehiculos.modelo = dr["modelo"].ToString();
                                vehiculos.anio = Convert.ToInt32(dr["anio"]);
                                vehiculos.color = dr["color"].ToString();
                                vehiculos.tipo = dr["tipo"].ToString();
                                vehiculos.estado = dr["estado"].ToString();
                                lista.Add(vehiculos);
                            }
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string ActualizarVehiculo(Vehiculos vehiculos)
        {
            string qury = @"
                UPDATE vehiculos
                SET marca = @marca, modelo = @modelo, anio = @anio, color = @color, tipo = @tipo, estado = @estado
                WHERE placa = @placa
            ";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(qury, con))
                    {
                        cmd.Parameters.AddWithValue("@placa", vehiculos.placa);
                        cmd.Parameters.AddWithValue("@marca", vehiculos.marca);
                        cmd.Parameters.AddWithValue("@modelo", vehiculos.modelo);
                        cmd.Parameters.AddWithValue("@anio", vehiculos.anio);
                        cmd.Parameters.AddWithValue("@color", vehiculos.color);
                        cmd.Parameters.AddWithValue("@tipo", vehiculos.tipo);
                        cmd.Parameters.AddWithValue("@estado", vehiculos.estado);
                        cmd.ExecuteNonQuery();
                    }
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string EliminarVehiculo(Vehiculos vehiculos)
        {
            string qury = @"
                DELETE FROM vehiculos
                WHERE placa = @placa
            ";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(qury, con))
                    {
                        cmd.Parameters.AddWithValue("@placa", vehiculos.placa);
                        cmd.ExecuteNonQuery();
                    }
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
