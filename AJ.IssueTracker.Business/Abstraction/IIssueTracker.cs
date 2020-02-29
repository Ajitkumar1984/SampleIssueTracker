using AJ.IssueTracker.Common.DTO;
using AJ.IssueTracker.Common.Model;
using AJ.IssueTracker.DataAccess.Abstraction;
using AJ.IssueTracker.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJ.IssueTracker.Business.Abstraction
{
  
    public interface IIssueTrackerService : IIssueTrackerDataService<Issue>
    {
        Task<IssueDTO> GetIssue(int Id);
        Task<IList<IssueDTO>> GetIssues(string number);
        Task<IssueDTO> CreateIssue(IssueDTO IssueDTO);
        Task<IssueDTO> UpdateIssue(IssueDTO IssueDTO);
        Task<bool> DeleteIssue(int Id);
        Task<Paging<IssueDTO>> GetIssues(PagingParameter pagingParameter);
    }
}
