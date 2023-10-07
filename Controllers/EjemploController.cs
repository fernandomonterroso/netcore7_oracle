using ApiNetCore7.Helpers;
using ApiNetCore7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiNetCore7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjemploController : ControllerBase
    {
        private readonly EjemploHandler _EjemploHandler;
        public EjemploController(EjemploHandler ejemploHandler)
        {
            _EjemploHandler = ejemploHandler;
        }

        [HttpGet("getValores")]
        public async Task<RespuestaHttp> Get()
        {
            return await _EjemploHandler.getPaciente();
        }
    }
}
