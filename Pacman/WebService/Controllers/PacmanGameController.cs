using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Models;
using WebService.Providers;

namespace WebService.Controllers
{
    public class PacmanGameController : ApiController
    {
        private readonly PacmanProvider _pacmanProvider = new PacmanProvider();
        [Route("api/pacmangame/GetInitialCherkers")]
        [HttpGet]
        public List<CheckerObject> GetInitialCherkers()
        {
            return _pacmanProvider.GetInitialCherkers();
        }

        [Route("api/pacmangame/GetStartPosition")]
        [HttpGet]
        public string GetStartPosition()
        {
            return _pacmanProvider.GetStartPosition();
        }

        [Route("api/pacmangame/GetOneStrategy")]
        [HttpGet]
        public List<StrategyObject> GetOneStrategy()
        {
            return _pacmanProvider.GetOneStrategy();
        }
    }
}
