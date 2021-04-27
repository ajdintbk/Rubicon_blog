using Rubicon_blog.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubicon_blog.DAL.ViewModel
{
    public class TagDto
    {
        public TagDto()
        {

        }
        public TagDto(Tag tag)
        {
            Slug = tag.Slug;
            Name = tag.Name;
        }

        public string Slug { get; set; }
        public string Name { get; set; }
    }
}
