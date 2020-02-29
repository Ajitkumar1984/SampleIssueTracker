using AJ.IssueTracker.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJ.IssueTracker.Services.Abstraction
{
   public  interface ITrackerService
    {
         Task<APICallResult<IList<IssueDTO>>> GetAllIssues();
        Task<APICallResult<IList<IssueDTO>>> GetAllIssues(string search);
        Task<APICallResult<IssueDTO>> GetIssues(string number);
         Task<APICallResult<IssueDTO>> CreateIssue(IssueDTO issue);
         Task<APICallResult<IssueDTO>> UpdateIssue(IssueDTO issue);
         Task<APICallResult<IList<CategoryDTO>>> GetAllCategories();
         Task<APICallResult<CategoryDTO>> GetCategory(string code);
    }
}
