using AJ.IssueTracker.Business.Abstraction;
using AJ.IssueTracker.Common.DTO;
using AJ.IssueTracker.Common.Model;
using AJ.IssueTracker.DataAccess;
using AJ.IssueTracker.DataAccess.Entities;
using AJ.IssueTracker.DataAccess.Service;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJ.IssueTracker.Business.Services
{
    public class CategoryService : IssueTracketDataService<Category>, ICategoryService
    {
        private readonly IMapper _mapper;
        public CategoryService(IssuetrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public async Task<IList<CategoryDTO>> GetCategories()
        {

            try
            {
                return this._mapper.Map<List<CategoryDTO>>(await this.GetAllAsyn());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
        public async Task<CategoryDTO> GetCategory(string name)
        {
            try
            {
                return this._mapper.Map<CategoryDTO>(await this.FindAsync(x => x.Code == name));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        public async Task<CategoryDTO> UpdateCategory(CategoryDTO Category)
        {
            try
            {
                Category category = this._mapper.Map<Category>(Category);
                category.ModifiedOn = DateTime.Now;
                await this.UpdateAsyn(category, category.CategoryId);
                return Category;
            }
            catch (DbEntityValidationException e)
            {
                string error = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    error = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    Console.WriteLine(error);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        error += "<br />" + string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new Exception(error);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}