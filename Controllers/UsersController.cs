using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using usertasks.Contracts;
using usertasks.Models;

namespace usertasks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
     
        private readonly IUsersRepository _repository;

        public UsersController(IUsersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
           _repository.Create(new User {
               FirstName = "asaf"
           });
           return _repository.FindAll().AsEnumerable();
        }
    }
}
