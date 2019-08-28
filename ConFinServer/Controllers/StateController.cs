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
    public class StateController : ControllerBase
    {
        [HttpGet("/states")]
        public List<State> All()
        {
            return StateRepository.All();
        }

        [HttpGet("/states/{est_sigla}")]
        public State Find()
        {
            string est_sigla = (string) Url.ActionContext.RouteData.Values["est_sigla"];

            return StateRepository.Find(est_sigla);
        }

        [HttpPost("/states")]
        public string Add(State state)
        {
            bool success = StateRepository.Add(state);

            return "State created with success";
        }

        [HttpPut("/states")]
        public string Update(State state)
        {
            bool success = StateRepository.Update(state);

            return "State updated with success";
        }

        [HttpDelete("/states")]
        public string Delete(State state)
        {
            bool success = StateRepository.Delete(state);

            return "State removed with success";
        }
    }
}