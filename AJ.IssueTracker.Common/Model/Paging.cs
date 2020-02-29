using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJ.IssueTracker.Common.Model
{
    public class Paging<T>
    {
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public List<int> Pages { get; set; }
        public List<T> Items { get; set; }
    }
}
