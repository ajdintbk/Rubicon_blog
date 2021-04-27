using Rubicon_blog.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubicon_blog.DAL.ViewModel
{
    public class TagsViewModel
    {
        public TagsViewModel(List<Tag> tags)
        {
            Tags = tags.Select(tag => new TagDto(tag)).ToList();
            TagsCount = tags.Count();
        }
        public List<TagDto> Tags { get; set; }
        public int TagsCount { get; set; }
    }
}
