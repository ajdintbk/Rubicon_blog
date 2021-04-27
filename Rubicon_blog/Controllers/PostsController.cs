using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rubicon_blog.DAL.Repositories;
using Rubicon_blog.DAL.Requests;
using Rubicon_blog.DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rubicon_blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPosts _service;

        public PostsController(IPosts service)
        {
            _service = service;
        }

        [HttpGet("{slug}")]
        [Produces("application/json")]
        public BlogPostViewModel Get(string slug)
        {
            var post = _service.GetPost(slug);
            return post;
        }

        [HttpGet]
        [Produces("application/json")]
        public BlogPostsViewModel GetPosts(string searchString)
        {
            var posts = _service.GetPosts(searchString);
            return posts;
        }

        [HttpPost]
        [Produces("application/json")]
        public BlogPostViewModel Create(BlogPostCreate request)
        {
            var posts = _service.Create(request);
            return posts;
        }

        [HttpPut("slug")]
        [Produces("application/json")]
        public BlogPostViewModel Update([Required] string slug, BlogPostUpdate request)
        {
            var post = _service.Update(slug, request);
            return post;
        }

        [HttpDelete("slug")]
        [Produces("application/json")]
        public IActionResult Delete([Required] string slug)
        {
            var post = _service.Delete(slug);
            if(post == null)
            {
                return BadRequest(error: "Post with slug '" + slug + "' does not exist.");
            }
            return Ok("Success");
        }
    }
}
