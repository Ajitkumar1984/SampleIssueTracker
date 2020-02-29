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
  
    public interface ICategoryService : IIssueTrackerDataService<Category>
    {        
        Task<CategoryDTO> GetCategory(string type);
        Task<CategoryDTO> UpdateCategory(CategoryDTO Category);
        Task<IList<CategoryDTO>> GetCategories();
    }
}
