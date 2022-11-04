using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ProductoDatos
    {
        public async Task<DataTable> DevolverListaAsync()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM producto";
                //consultar un solo usuario
                //string sql = "SELECT * FROM usuario WHERE Codigo =@Codigo";
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        //tipo comando: texto
                        comando.CommandType = System.Data.CommandType.Text;
                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public async Task<bool> InsertarAsync(Producto producto)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO producto VALUES (@Codigo, @Descripcion, @Existencia, @Precio, @FechaCreacion, @Imagen)";

                //conexion de mysql
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.Int32).Value = producto.Codigo;
                        comando.Parameters.Add("@Descripcion", MySqlDbType.VarChar, 50).Value = producto.Descripcion;
                        comando.Parameters.Add("@Existencia", MySqlDbType.Int32).Value = producto.Existencia;
                        comando.Parameters.Add("@FechaCreacion", MySqlDbType.DateTime).Value = producto.FechaCreacion;
                        comando.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = producto.Precio;
                        comando.Parameters.Add("@Imagen", MySqlDbType.LongBlob).Value = producto.Imagen;

                        await comando.ExecuteNonQueryAsync();
                        inserto = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return inserto;
        }

        public async Task<bool> ActualizarAsync(Producto producto)
        {
            bool actualizo = false;
            try
            {
                string sql = "UPDATE producto SET Descripcion=@Descripcion, Existencia=@Existencia, Precio=@Precio, FechaCreacion=@FechaCreacion, Imagen=@Imagen WHERE Codigo=@Codigo";
                //conexion de mysql
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.Int32).Value = producto.Codigo;
                        comando.Parameters.Add("@Descripcion", MySqlDbType.VarChar, 50).Value = producto.Descripcion;
                        comando.Parameters.Add("@Existencia", MySqlDbType.Int32).Value = producto.Existencia;
                        comando.Parameters.Add("@FechaCreacion", MySqlDbType.DateTime).Value = producto.FechaCreacion;
                        comando.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = producto.Precio;
                        comando.Parameters.Add("@Imagen", MySqlDbType.LongBlob).Value = producto.Imagen;

                        await comando.ExecuteNonQueryAsync();
                        actualizo = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return actualizo;
        }

        public async Task<bool> EliminarAsync(string codigo)
        {
            bool elimino = false;
            try
            {
                string sql = "DELETE FROM producto WHERE Codigo = @Codigo";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.Int32).Value = codigo;
                        await comando.ExecuteNonQueryAsync();
                        elimino = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return elimino;
        }

        public async Task<byte[]> SeleccionarImagen(string codigo)
        {
            byte[] imagen = new byte[0];
            try
            {
                string sql = "SELECT Image FROM producto WHERE Codigo = @Codigo";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.Int32).Value = codigo;

                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        if (dr.Read())
                        {
                            imagen = (byte[])dr["imagen"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return imagen;
        }

    }
}

