using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubicon_blog.DAL.Domain
{
    public class PostTag
    {
        public string BlogPostSlug { get; set; }
        public BlogPost BlogPost { get; set; }
        public string TagSlug { get; set; }
        public Tag Tag { get; set; }
    }
}
