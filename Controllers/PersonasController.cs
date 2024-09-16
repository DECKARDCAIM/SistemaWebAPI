using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaWebAppi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        [HttpPost]
        [Route("guardar")]
        public ActionResult<object> guardar([FromBody] Repository.Personas personas)
        {
            string res = personas.GuardarPersonas();
            if (res == "")
            {
                return Ok(new
                {
                    cod_error = 0,
                    mensaje = "Persona guardada"
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
        [Route("listar")]
        public ActionResult<object> listar()
        {
            Repository.Personas personas = new Repository.Personas();
            return Ok(personas.ListarPersonas());
        }
    }
}
