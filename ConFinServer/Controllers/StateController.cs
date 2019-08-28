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
    public class StateController : ControllerBase
    {
        [HttpGet("/states")]
        public List<State> ListStates()
        {
            return StateDB.GetStates();
        }

        [HttpGet("/states/{est_sigla}")]
        public State ListState()
        {
            string est_sigla = (string) Url.ActionContext.RouteData.Values["est_sigla"];

            return StateDB.GetState(est_sigla);
        }

        [HttpPost("/states")]
        public string CreateState(State state)
        {
            bool success = StateDB.AddState(state);

            return "State created with success";
        }

        [HttpPut("/states")]
        public string UpdateState(State state)
        {
            bool success = StateDB.ChangeState(state);

            return "State updated with success";
        }

        [HttpDelete("/states")]
        public string DeleteState(State state)
        {
            bool success = StateDB.RemoveState(state);

            return "State removed with success";
        }
    }
}