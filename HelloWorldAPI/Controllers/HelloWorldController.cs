using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldAPI.Interfaces;
using HelloWorldAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        private readonly IHelloWorldRepository _repo;

        public HelloWorldController(IHelloWorldRepository repo)
        {
            _repo = repo;

            if (_repo.ListAll().Count() == 0)
            {
                _repo.Add();
            }
        }

        [HttpGet]
        public ActionResult<List<HelloWorldModel>> GetAll()
        {
            return _repo.ListAll().ToList();
        }

        [HttpGet("{id}", Name = "GetHelloWorld")]
        public ActionResult<HelloWorldModel> GetById(long id)
        {
            var item = _repo.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }
    }
}
