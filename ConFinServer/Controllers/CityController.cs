using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConFinServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private static List<City> cities = new List<City>();

        [HttpGet("/cities")]
        public List<City> ListCities()
        {
            return cities;
        }

        [HttpPost("/cities")]
        public string CreateState(City city)
        {
            cities.Add(city);

            return "City created with success";
        }

        [HttpPut("/cities")]
        public string UpdateState(City city)
        {
            City previousCity = cities.Where(c => c.cid_codigo == city.cid_codigo).First();
                /*.Select(c => {c.nome = city.nome; c.est_sigla = city.est_sigla; return c;})
                .ToList();*/

            cities.Remove(previousCity);
            cities.Add(city);

            return "City updated with success";
        }

        [HttpDelete("/cities")]
        public string DeleteState(City city)
        {
            City cityToRemove = cities.Where(c => c.cid_codigo == city.cid_codigo).Select(c => c).First();

            cities.Remove(cityToRemove);

            return "City removed with success";
        }
    }
}