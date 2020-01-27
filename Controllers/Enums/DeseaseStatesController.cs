using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Enums;

namespace MedalynxAPI.Controllers.Enums
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    public class DeseaseStatesController : MedalynxControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<DeseaseStateItem>> GetAll() {
            List<DeseaseStateItem> items = Program.MedialynxData.deseaseStatesDBAPI.GetEnum();
            return items;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DeseaseStateItem> GetById(string id/*guid*/)
        {
            string sid = Utils.ToGuid(id, false).ToString("B");
            List<DeseaseStateItem> items = Program.MedialynxData.deseaseStatesDBAPI.GetEnum(sid);
            if (items.Count != 1)
            {
                return NotFound();
            }

            return items[0];
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DeseaseStateItem> Create(DeseaseStateItem item)
        {
            Guid id = Utils.ToGuid(item.Id, false);
            if (id == Guid.Empty) {
                item.Id = Guid.NewGuid().ToString("B");
            }
            Program.MedialynxData.deseaseStatesDBAPI.AddItem(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }
    }
}
