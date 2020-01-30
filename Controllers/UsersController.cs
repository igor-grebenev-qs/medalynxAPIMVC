using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;

namespace MedalynxAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    public class UsersController : MedalynxControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<User>> GetAll() {
            List<User> users = Program.MedialynxData.userDBAPI.GetUser();
            return users;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetById(string id/*guid*/)
        {
            string sid = Utils.ToGuid(id, false).ToString("B");
            List<User> users = Program.MedialynxData.userDBAPI.GetUser(sid);
            if (users.Count != 1)
            {
                return NotFound();
            }

            return users[0];
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> Create(User user)
        {
            Guid id = Utils.ToGuid(user.Id, false);
            user.CreationDate = DateTime.UtcNow;
            user.LastUpdate = user.CreationDate;
            if (id == Guid.Empty) {
                user.Id = Guid.NewGuid().ToString("B");
                Program.MedialynxData.userDBAPI.AddUser(user);
                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> Update(User user)
        {
            Guid id = Utils.ToGuid(user.Id, false);
            if (id == Guid.Empty) {
                return BadRequest();
            }
            user.LastUpdate = DateTime.UtcNow;
            Program.MedialynxData.userDBAPI.UpdateUser(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
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
