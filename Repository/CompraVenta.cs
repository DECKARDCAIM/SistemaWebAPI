using Microsoft.Data.SqlClient;

namespace SistemaWebAppi.Repository
{
    public class CompraVenta
    {
        private string connectionString = "Server=svr-sql-ctezo.southcentralus.cloudapp.azure.com;Database=db_banco;User Id=usr_admin;Password=usrGuastaUMG!ng;TrustServerCertificate= True";
        public int idcompraventa { get; set; }
        public string placa { get; set; }
        public string cuicomprador { get; set; }
        public string cuivendedor { get; set; }
        public decimal precioventa { get; set; }

        public string GuardarCompraVenta(CompraVenta compraventa)
        {
            string query = @"
                INSERT INTO compraventa(placa, cuicomprador, cuivendedor, precioventa)
                VALUES (@placa, @cuicomprador, @cuivendedor, @precioventa)
            ";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@placa", compraventa.placa);
                        cmd.Parameters.AddWithValue("@cuicomprador", compraventa.cuicomprador);
                        cmd.Parameters.AddWithValue("@cuivendedor", compraventa.cuivendedor);
                        cmd.Parameters.AddWithValue("@precioventa", compraventa.precioventa);
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

        public List<CompraVenta> ListarCompraVenta()
        {
            List<CompraVenta> lista = new List<CompraVenta>();
            string query = @"
                SELECT idcompraventa, placa, cuicomprador, cuivendedor, precioventa
                FROM compraventa
            ";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                CompraVenta compraventa = new CompraVenta();
                                compraventa.idcompraventa = dr.GetInt32(0);
                                compraventa.placa = dr.GetString(1);
                                compraventa.cuicomprador = dr.GetString(2);
                                compraventa.cuivendedor = dr.GetString(3);
                                compraventa.precioventa = dr.GetDecimal(4);
                                lista.Add(compraventa);
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

        public string ActualizarCompraVenta(CompraVenta compraventa)
        {
            string query = @"
                UPDATE compraventa
                SET placa = @placa, cuicomprador = @cuicomprador, cuivendedor = @cuivendedor, precioventa = @precioventa
                WHERE idcompraventa = @idcompraventa
            ";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idcompraventa", compraventa.idcompraventa);
                        cmd.Parameters.AddWithValue("@placa", compraventa.placa);
                        cmd.Parameters.AddWithValue("@cuicomprador", compraventa.cuicomprador);
                        cmd.Parameters.AddWithValue("@cuivendedor", compraventa.cuivendedor);
                        cmd.Parameters.AddWithValue("@precioventa", compraventa.precioventa);
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

        public string EliminarCompraVenta(int idcompraventa)
        {
            string query = @"
                DELETE FROM compraventa
                WHERE idcompraventa = @idcompraventa
            ";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idcompraventa", idcompraventa);
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

        public List<CompraVenta> ConsultarHistorial(string placa)
        {
            List<CompraVenta> lista = new List<CompraVenta>();
            string query = @"
                SELECT idcompraventa, placa, cuicomprador, cuivendedor, precioventa
                FROM compraventa
                WHERE placa = @placa
            ";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@placa", placa);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                CompraVenta compraventa = new CompraVenta();
                                compraventa.idcompraventa = dr.GetInt32(0);
                                compraventa.placa = dr.GetString(1);
                                compraventa.cuicomprador = dr.GetString(2);
                                compraventa.cuivendedor = dr.GetString(3);
                                compraventa.precioventa = dr.GetDecimal(4);
                                lista.Add(compraventa);
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
    }
}
