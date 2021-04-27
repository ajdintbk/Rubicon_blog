using System.ComponentModel.DataAnnotations;

namespace Rubicon_blog.DAL.Domain
{
    public class Tag
    {
        [Key]
        public string Slug { get; set; }
        public string Name { get; set; }
    }
}