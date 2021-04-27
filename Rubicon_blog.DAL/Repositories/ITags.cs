using Rubicon_blog.DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubicon_blog.DAL.Repositories
{
    public interface ITags
    {
        TagsViewModel Get();
    }
}
