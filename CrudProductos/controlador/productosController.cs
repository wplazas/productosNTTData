using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CrudProductos.modelo;
using System.Data;
using System.Data.SqlClient;

namespace pruebaTecnicaSTG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productosController : ControllerBase
    {
        private readonly string conexion;

        public productosController(IConfiguration cadcon)
        {
            conexion = cadcon.GetConnectionString("mycon");
        }


        [HttpPost]
        [Route("productoSave")]
        [Authorize]

        public IActionResult productoSave([FromBody] Productos entity)
        {
            try
            {
                using (var conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    var cmd = new SqlCommand("sp_productoinsert", conn);
                    cmd.Parameters.AddWithValue("categoria", entity.categoria);
                    cmd.Parameters.AddWithValue("nombre", entity.nombre);
                    cmd.Parameters.AddWithValue("unidades", entity.unidades);
                    cmd.Parameters.AddWithValue("fechaingreso", entity.fechaingreso);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }
                return StatusCode(statusCode: 200, new { mensaje = "ok" });


            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 500, new { mensaje = ex.Message });

            }


        }

        [HttpPut]
        [Route("productoUpdate")]
        [Authorize]

        public IActionResult productoUpdate([FromBody] Productos entity)
        {
            try
            {
                using (var conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    var cmd = new SqlCommand("sp_productoupdate", conn);
                    cmd.Parameters.AddWithValue("id", entity.id);
                    cmd.Parameters.AddWithValue("categoria", entity.categoria);
                    cmd.Parameters.AddWithValue("nombre", entity.nombre);
                    cmd.Parameters.AddWithValue("fechaingreso", entity.fechaingreso);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }
                return StatusCode(statusCode: 200, new { mensaje = "ok" });


            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 500, new { mensaje = ex.Message });

            }


        }


        [HttpDelete]
        [Route("productodelete")]
        [Authorize]

        public IActionResult productodetele(int id)
        {
            try
            {
                using (var conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    var cmd = new SqlCommand("sp_productodelete", conn);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }
                return StatusCode(statusCode: 200, new { mensaje = "ok" });


            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 500, new { mensaje = ex.Message });

            }


        }


        [HttpGet]
        [Route("productoconsulta")]
        [Authorize]

        public IActionResult productoconsulta(string nombre)
        {
            try
            {
                using (var conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    var cmd = new SqlCommand("sp_productoconsulta", conn);
                    cmd.Parameters.AddWithValue("nombre", nombre);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }
                return StatusCode(statusCode: 200, new { mensaje = "ok" });


            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 500, new { mensaje = ex.Message });

            }


        }



    }

}
