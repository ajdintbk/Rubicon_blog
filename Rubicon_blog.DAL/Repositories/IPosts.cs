using Rubicon_blog.DAL.Domain;
using Rubicon_blog.DAL.Requests;
using Rubicon_blog.DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubicon_blog.DAL.Repositories
{
    public interface IPosts
    {
        BlogPostViewModel GetPost(string slug);
        BlogPostsViewModel GetPosts(string searchString);
        BlogPostViewModel Create(BlogPostCreate post);
        BlogPostViewModel Update(string slug, BlogPostUpdate post);
        BlogPostViewModel Delete(string slug);
    }
}
