using System;
using MySql.Data.MySqlClient;
namespace consultas
{
    public class Consultas
    {
        public Consultas(){
            
        }

        public decimal ObtenerPresupuesto(int id, MySqlConnection conexion)
        {
            decimal presupuestos =0;
            string query = "SELECT dinero FROM presupuesto WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        presupuestos = rdr.GetDecimal("dinero");
                        Console.WriteLine($"Dinero del Id {id}: {presupuestos}");
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró nada en el ID solicitado {id}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al comprobar el dinero: " + ex.Message);
            }
            return presupuestos;
        }

        public bool ActualizarDinero(int id, decimal dineroNuevo, MySqlConnection conexion)
        {
            bool bandera = false;
            string query = "UPDATE presupuesto SET dinero = @dineroNuevo WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@dineroNuevo", dineroNuevo);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    bandera = true;
                }
                else
                {
                    bandera = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el dinero: " + ex.Message);
            }
            return bandera;
        }
    }
}
