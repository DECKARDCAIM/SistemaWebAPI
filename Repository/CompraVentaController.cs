using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaWebAppi.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraVentaController : ControllerBase
    {
        [HttpPost]
        [Route("GuardarCompraVenta")]
        public ActionResult<object> GuardarCompraVenta([FromBody] CompraVenta compraventa)
        {
            string res = compraventa.GuardarCompraVenta(compraventa);
            if (res == "")
            {
                return Ok(new
                {
                    cod_error = 0,
                    mensaje = "CompraVenta guardado"
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

        [HttpGet]
        [Route("ListarCompraVenta")]
        public ActionResult<object> ListarCompraVenta()
        {
            List<CompraVenta> lista = new CompraVenta().ListarCompraVenta();
            return Ok(new
            {
                cod_error = 0,
                mensaje = "Lista de CompraVenta",
                data = lista
            });
        }

        [HttpPut]
        [Route("ActualizarCompraVenta")]
        public ActionResult<object> ActualizarCompraVenta([FromBody] CompraVenta compraventa)
        {
            string res = compraventa.ActualizarCompraVenta(compraventa);
            if (res == "")
            {
                return Ok(new
                {
                    cod_error = 0,
                    mensaje = "CompraVenta actualizado"
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
        [Route("EliminarCompraVenta")]
        public ActionResult<object> EliminarCompraVenta(int idcompraventa)
        {
            string res = new CompraVenta().EliminarCompraVenta(idcompraventa);
            if (res == "")
            {
                return Ok(new
                {
                    cod_error = 0,
                    mensaje = "CompraVenta eliminado"
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

        [HttpGet]
        [Route("ConsultarHistorial")]
        public ActionResult<object> ConsultarHistorial(string placa)
        {
            List<CompraVenta> lista = new CompraVenta().ConsultarHistorial(placa);
            return Ok(new
            {
                cod_error = 0,
                mensaje = "Historial de CompraVenta",
                data = lista
            });
        }

    }
}
