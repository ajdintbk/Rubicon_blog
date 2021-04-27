using Microsoft.EntityFrameworkCore;
using Rubicon_blog.DAL.Domain;
using Rubicon_blog.DAL.Requests;
using Rubicon_blog.DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Rubicon_blog.DAL.Repositories
{
    public class BlogPostRepository : IPosts
    {
        private readonly BlogDbContext _context;
        public BlogPostRepository(BlogDbContext context)
        {
            _context = context;
        }

        public BlogPostViewModel Create(BlogPostCreate post)
        {
            
            var PostDomain = new BlogPost()
            {
                Body = post.Body,
                CreatedAt = DateTime.Now,
                Description = post.Description,
                Slug = SlugHelper.ToUrlSlug(post.Title),
                Title = post.Title
            };

            if(post.TagList != null || post.TagList.Count > 0)
            {
                foreach (var tag in post.TagList)
                {
                    if(_context.Tags.FirstOrDefault(w => w.Slug.ToLower() == tag.ToLower()) == null)
                    {
                        Tag newTag = new Tag
                        {
                            Name = tag,
                            Slug = SlugHelper.ToUrlSlug(tag)
                        };
                        _context.Tags.Add(newTag);
                    }
                    PostTag pt = new PostTag()
                    {
                        BlogPostSlug = PostDomain.Slug,
                        TagSlug = SlugHelper.ToUrlSlug(tag)
                    };
                    _context.PostTags.Add(pt);
                }
            }

            _context.Posts.Add(PostDomain);
            _context.SaveChanges();

            return new BlogPostViewModel(PostDomain);
        }

        public BlogPostViewModel Delete(string slug)
        {
            var post = _context.Posts.FirstOrDefault(w => w.Slug == slug);
            if (post == null)
                return null;
            _context.Posts.Remove(post);
            _context.SaveChanges();

            return new BlogPostViewModel(post);
        }

        public BlogPostViewModel GetPost(string slug)
        {
            var post = _context.Posts.Include(i=>i.TagList).FirstOrDefault(w => w.Slug == slug);
            return new BlogPostViewModel(post);
        }

        public BlogPostsViewModel GetPosts(string searchString)
        {
            var query = _context.Posts.Include(i => i.TagList).AsQueryable();
            
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(w => w.TagList.Any(a=>a.Tag.Name.ToLower() == searchString.ToLower()));
            }
            return new BlogPostsViewModel(query.OrderBy(x=>x.CreatedAt).ToList());
        }

        public BlogPostViewModel Update(string slug, BlogPostUpdate post)
        {
            var domainPost = _context.Posts.FirstOrDefault(w => w.Slug == slug);
            if (domainPost == null)
                return null;

            if(post.Title != null)
            {
                domainPost.Title = post.Title;
                //domainPost.Slug = SlugHelper.ToUrlSlug(post.Title); //slug is primary key so it should not be updated(?) because of fundamental rule of database development
            }
            if(post.Description != null)
            domainPost.Description = post.Description;
            if(post.Body != null)
                domainPost.Body = post.Body;
            domainPost.UpdatedAt = DateTime.Now;

            _context.Update(domainPost);
            _context.SaveChanges();

            return new BlogPostViewModel(domainPost);
        }
    }
}