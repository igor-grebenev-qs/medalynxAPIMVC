﻿using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedalynxAPI.Models;
using MedalynxAPI.Models.User;

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
            return Program.MedialynxData.userDBAPI.Get();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetById(string id)
        {
            string sid = Utils.ToGuid(id, false).ToString("B");
            List<User> users = Program.MedialynxData.userDBAPI.Get(sid);
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
                Program.MedialynxData.userDBAPI.Add(user);
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
            Program.MedialynxData.userDBAPI.Update(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpOptions]
        [HttpOptions("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Enviroment> Options()
        {
            return Ok();
        }
    }
}