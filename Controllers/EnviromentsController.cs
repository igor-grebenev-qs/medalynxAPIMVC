using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;

namespace MedalynxAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("Environments")]
    public class EnviromentsController : MedalynxControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Enviroment>> GetAll() {
            List<Enviroment> enviroments = Program.MedialynxData.enviromentDBAPI.GetEnviroment();
            return enviroments;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Enviroment> GetById(string id/*guid*/)
        {
            string sid = Utils.ToGuid(id, false).ToString("B");
            List<Enviroment> enviroments = Program.MedialynxData.enviromentDBAPI.GetEnviroment(sid);
            if (enviroments.Count != 1)
            {
                return NotFound();
            }

            return enviroments[0];
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Enviroment> Create(Enviroment enviroment)
        {
            Guid id = Utils.ToGuid(enviroment.Id, false);
            if (id == Guid.Empty) {
                enviroment.Id = Guid.NewGuid().ToString("B");
            }
            Program.MedialynxData.enviromentDBAPI.AddEnviroment(enviroment);
            return CreatedAtAction(nameof(GetById), new { id = enviroment.Id }, enviroment);
        }

        [HttpOptions]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Enviroment> Options()
        {
            return Ok();
        }
    }
}
