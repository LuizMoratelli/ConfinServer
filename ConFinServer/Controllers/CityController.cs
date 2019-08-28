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
        public List<City> All()
        {
            return CityRepository.All();
        }

        [HttpGet("/cities/{cid_codigo}")]
        public City Find()
        {
            int cid_codigo = Convert.ToInt32(Url.ActionContext.RouteData.Values["cid_codigo"]);

            return CityRepository.Find(cid_codigo);
        }

        [HttpPost("/cities")]
        public string Add(City city)
        {
            bool success = CityRepository.Add(city);

            return "City created with success";
        }

        [HttpPut("/cities")]
        public string Update(City city)
        {
            bool success = CityRepository.Update(city);

            return "City updated with success";
        }

        [HttpDelete("/cities")]
        public string Delete(City city)
        {
            bool success = CityRepository.Delete(city);

            return "City removed with success";
        }
    }
}