using AJ.IssueTracker.Common.DTO;
using AJ.IssueTracker.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJ.IssueTracker.Services
{
   public class TrackerService: ITrackerService
    {
        private readonly IWebAPICaller _apiCaller = new WebAPICaller("https://localhost:44322/");

      
        public async Task<APICallResult<IList<IssueDTO>>> GetAllIssues()
        {
            return await this._apiCaller.GetAsJsonAsync<IList<IssueDTO>>("api/IssueTracker?number");
        }

        public async Task<APICallResult<IList<IssueDTO>>> GetAllIssues(string searchpattern)
        {
            return await this._apiCaller.GetAsJsonAsync<IList<IssueDTO>>("api/IssueTracker?number="+searchpattern);
        }
        public async Task<APICallResult<IssueDTO>> GetIssues(string number)
        {
            return await this._apiCaller.GetAsJsonAsync<IssueDTO>("api/IssueTracker?id=" + number);
        }

        public async Task<APICallResult<IssueDTO>> CreateIssue(IssueDTO issue)
        {
            return await this._apiCaller.PostAsJsonAsync<IssueDTO, IssueDTO>("api/IssueTracker", issue);
        }
        public async Task<APICallResult<IssueDTO>> UpdateIssue(IssueDTO issue)
        {
            return await this._apiCaller.PutAsJsonAsync<IssueDTO, IssueDTO>("api/IssueTracker", issue);
        }

        public async Task<APICallResult<IList<CategoryDTO>>> GetAllCategories()
        {
            return await this._apiCaller.GetAsJsonAsync<IList<CategoryDTO>>("api/Category");
        }

        public async Task<APICallResult<CategoryDTO>> GetCategory(string code)
        {
            return await this._apiCaller.GetAsJsonAsync<CategoryDTO>("api/Category?code=" + code);
        }
    }
}
