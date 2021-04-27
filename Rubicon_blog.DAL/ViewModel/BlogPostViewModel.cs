using Rubicon_blog.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubicon_blog.DAL.ViewModel
{
    public class BlogPostViewModel
    {
        public BlogPostViewModel(BlogPost post)
        {
            BlogPost = new BlogPostDto(post);
        }
        public BlogPostDto BlogPost{ get; set; }
    }
}
