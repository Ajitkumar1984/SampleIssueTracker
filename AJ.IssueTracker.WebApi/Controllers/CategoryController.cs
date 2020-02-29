using AJ.IssueTracker.Business.Abstraction;
using AJ.IssueTracker.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AJ.IssueTracker.WebApi.Controllers
{
    public class CategoryController : ApiController
    {
        private ICategoryService _CategoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }
        // GET api/<controller>
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            var lst = await _CategoryService.GetCategories();
            return lst.ToList();
        }

        // GET api/<controller>/CD
        public async Task<CategoryDTO> Get(string code)
        {
            var lst = await _CategoryService.GetCategory(code);
            return lst;
        }

    }
}
