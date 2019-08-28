using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConFinServer.Models;
using ConFinServer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpGet("/cities")]
        public List<City> ListCities()
        {
            return CityDB.GetCities();
        }

        [HttpGet("/cities/{cid_codigo}")]
        public City ListCity()
        {
            int cid_codigo = Convert.ToInt32(Url.ActionContext.RouteData.Values["cid_codigo"]);

            return CityDB.GetCity(cid_codigo);
        }

        [HttpPost("/cities")]
        public string CreateCity(City city)
        {
            bool success = CityDB.AddCity(city);

            return "City created with success";
        }

        [HttpPut("/cities")]
        public string UpdateCity(City city)
        {
            bool success = CityDB.ChangeCity(city);

            return "City updated with success";
        }

        [HttpDelete("/cities")]
        public string DeleteCity(City city)
        {
            bool success = CityDB.RemoveCity(city);

            return "City removed with success";
        }
    }
}