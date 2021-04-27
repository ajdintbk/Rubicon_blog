using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rubicon_blog.DAL.Repositories;
using Rubicon_blog.DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rubicon_blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITags _service;

        public TagsController(ITags service)
        {
            _service = service;
        }

        [HttpGet]
        [Produces("application/json")]
        public TagsViewModel GetPosts()
        {
            return _service.Get();
            
        }
    }
}
