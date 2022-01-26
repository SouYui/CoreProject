using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence;

namespace WebAPI.Controllers
{
    // http://localhost:5000/WeatherForecast
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // Inyeccion de dependencias
        private readonly BellotaContext context;

        public WeatherForecastController(BellotaContext context) {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Administrador> Get() {
            return context.Administrador.ToList();
        }
    }
}
