using Rubicon_blog.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubicon_blog.DAL.ViewModel
{
    public class BlogPostsViewModel
    {
        public BlogPostsViewModel(List<BlogPost> posts)
        {
            BlogPosts = posts.Select(post => new BlogPostDto(post)).ToList();
            PostsCount = posts.Count();
        }
        public List<BlogPostDto> BlogPosts { get; set; }
        public int PostsCount { get; set; }
    }
}
