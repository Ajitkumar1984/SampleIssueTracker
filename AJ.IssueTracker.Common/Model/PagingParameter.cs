using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJ.IssueTracker.Common.Model
{
    public class PagingParameter
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public string SortField { get; set; }
        public string SortOrder { get; set; }
        public string SearchCriteria { get; set; }
    }
}
