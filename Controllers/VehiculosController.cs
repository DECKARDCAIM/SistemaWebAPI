using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaWebAppi.Repository;

namespace SistemaWebAppi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        //Controlador para guardar un vehiculo
        [HttpPost]
        [Route("guardar")]
        public ActionResult<object> guardar([FromBody] Repository.Vehiculos vehiculos)
        {
            string res = vehiculos.GuardarVehiculo(vehiculos);
            if (res == "")
            {
                return Ok(new
                {
                    cod_error= 0,
                    mensaje = "Vehiculo guardado"
                });
            }
            else
            {
                return Ok(new
                {
                    cod_error = -1000,
                    mensaje = res
                });
            }
        }


        //Controlador para listar los vehiculos
        [HttpGet]
        [Route("listar")]
        public ActionResult<object> listar()
        {
            Repository.Vehiculos vehiculos = new Repository.Vehiculos();
            return Ok(vehiculos.ListarVehiculos());
        }

        [HttpPut]
        [Route("actualizar")]
        public ActionResult<object> actualizar([FromBody] Repository.Vehiculos vehiculos)
        {
            string res = vehiculos.ActualizarVehiculo(vehiculos);
            if (res == "")
            {
                return Ok(new
                {
                    cod_error = 0,
                    mensaje = "Vehiculo actualizado"
                });
            }
            else
            {
                return Ok(new
                {
                    cod_error = -1000,
                    mensaje = res
                });
            }
        }

        [HttpDelete]
        [Route("eliminar")]
        public ActionResult<object> eliminar([FromBody] Repository.Vehiculos vehiculos)
        {
            string res = vehiculos.EliminarVehiculo(vehiculos);
            if (res == "")
            {
                return Ok(new
                {
                    cod_error = 0,
                    mensaje = "Vehiculo eliminado"
                });
            }
            else
            {
                return Ok(new
                {
                    cod_error = -1000,
                    mensaje = res
                });
            }
        }
    }
}
