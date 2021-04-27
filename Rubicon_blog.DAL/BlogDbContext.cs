using Microsoft.EntityFrameworkCore;
using Rubicon_blog.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubicon_blog.DAL
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }
        public DbSet<BlogPost> Posts{ get; set; }
        public DbSet<Tag> Tags{ get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasData(new List<Tag> {
                    new Tag
                    {
                        Slug = "ios",
                        Name = "iOS"
                    },
                    new Tag
                    {
                        Slug = "ar",
                        Name = "Augmented Reality"
                    },
                    new Tag
                    {
                        Slug = "gazzda",
                        Name = "Gazzda"
                    }
                });
            });
            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.HasMany(e => e.TagList).WithOne(w => w.BlogPost);
                entity.HasData(new List<BlogPost>
                {
                    new BlogPost
                    {
                        Slug = "augmented-reality-ios-application",
                        Title = "Augmented Reality iOS Application",
                        Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                        Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new BlogPost
                    {
                        Slug = "augmented-reality-ios-application-2",
                        Title = "Augmented Reality iOS Application 2",
                        Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                        Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                });
            });

            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasKey(b => new { b.BlogPostSlug, b.TagSlug });
                entity.HasData(new PostTag
                {
                    BlogPostSlug = "augmented-reality-ios-application",
                    TagSlug = "ar"
                });

                entity.HasData(new PostTag
                {
                    BlogPostSlug = "augmented-reality-ios-application",
                    TagSlug = "ios"
                });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
