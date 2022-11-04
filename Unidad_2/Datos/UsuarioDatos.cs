using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class UsuarioDatos
    {
        public async Task<bool> LoginAsync(string codigo, string clave)
        {
            bool valido = false;
            try
            {
                string sql = "SELECT 1 FROM usuario WHERE Codigo=@Codigo AND Clave=@Clave;";

                //conexion de mysql
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        //tipo comando: texto
                        comando.CommandType = System.Data.CommandType.Text;
                        //er en base de datos 
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 20).Value = codigo;
                        comando.Parameters.Add("@Clave", MySqlDbType.VarChar, 120).Value = clave;

                        valido = Convert.ToBoolean(await comando.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return valido;
            //metodo para validar si un usuario esta loogueado correctamente o no
        }


        //metodo que va permitir consultar todos los usuarios o devolver los usuarios que tengo en mi tabla usuario
        public async Task<DataTable> DevolverListaAsync()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM usuario";
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


        //metodo insertar un nuevo usuario
        public async Task<bool> InsertarAsync(Usuario usuario)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO usuario VALUES (@Codigo, @Nombre, @Clave, @Correo, @Rol, @EstaActivo)";

                //conexion de mysql
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 20).Value = usuario.Codigo;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 50).Value = usuario.Nombre;
                        comando.Parameters.Add("@Clave", MySqlDbType.VarChar, 120).Value = usuario.Clave;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 45).Value = usuario.Correo;
                        comando.Parameters.Add("@Rol", MySqlDbType.VarChar, 20).Value = usuario.Rol;
                        comando.Parameters.Add("@EstaActivo", MySqlDbType.Bit).Value = usuario.EstaActivo;

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


        //metodo actualizar usuario
        public async Task<bool> ActualizarAsync(Usuario usuario)
        {
            bool actualizo = false;
            try
            {
                string sql = "UPDATE usuario SET Nombre=@Nombre, Clave=@Clave, Correo=@Correo, Rol=@Rol, EstaActivo=@EstaActivo WHERE Codigo=@Codigo";
                //conexion de mysql
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 20).Value = usuario.Codigo;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 50).Value = usuario.Nombre;
                        comando.Parameters.Add("@Clave", MySqlDbType.VarChar, 120).Value = usuario.Clave;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 45).Value = usuario.Correo;
                        comando.Parameters.Add("@Rol", MySqlDbType.VarChar, 20).Value = usuario.Rol;
                        comando.Parameters.Add("@EstaActivo", MySqlDbType.Bit).Value = usuario.EstaActivo;

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


        //metodo eliminar
        public async Task<bool> EliminarAsync(string codigo)
        {
            bool elimino = false;
            try
            {
                string sql = "DELETE FROM usuario WHERE Codigo = @Codigo";
                //conexion de mysql
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 20).Value = codigo;
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
    }
}
