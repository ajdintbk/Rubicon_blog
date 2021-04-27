using Rubicon_blog.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubicon_blog.DAL.ViewModel
{
    public class BlogPostDto
    {
        public BlogPostDto()
        {

        }
        public BlogPostDto(BlogPost post)
        {
            Slug = post.Slug;
            Title = post.Title;
            Description = post.Description;
            Body = post.Body;
            TagList = new List<string>();
            if(post.TagList != null)
            {
                foreach (var tag in post.TagList)
                {
                    TagList.Add(tag.TagSlug);
                }
            }
            CreatedAt = post.CreatedAt.ToString();
            UpdatedAt = post.UpdatedAt.ToString();
        }

        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public List<string> TagList { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
