using Rubicon_blog.DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubicon_blog.DAL.Repositories
{
    public class TagsRepository : ITags
    {
        private readonly BlogDbContext _context;
        public TagsRepository(BlogDbContext context)
        {
            _context = context;
        }
        public TagsViewModel Get()
        {
            var tags = _context.Tags.ToList();
            return new TagsViewModel(tags);
        }
    }
}
