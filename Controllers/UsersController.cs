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
        private static readonly List<User> _usersInMemoryStore = new List<User>();

        public UsersController()
        {
            if (_usersInMemoryStore.Count == 0)
            {
                _usersInMemoryStore.Add(
                    new User 
                    { 
                        Id = "{9ccf25f2-2500-4af3-a64c-10f3f83d8da1}",
                        Email = "igor.ge@mail.ru",
                        FirstName = "Igor (Simple runtime)",
                        LastName = "Grebenev",
                        CompanyName = "Quantumsoft",
                        Request = RequestType.Created,
                        Password = ""
                    });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<User>> GetAll() {
            return _usersInMemoryStore;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetById(string id/*guid*/)
        {
            User user = _usersInMemoryStore.FirstOrDefault(user => user.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> Create(User user)
        {
            // Create new guid for new user
            user.Id = Guid.NewGuid().ToString("B");
            _usersInMemoryStore.Add(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }
    }
}
