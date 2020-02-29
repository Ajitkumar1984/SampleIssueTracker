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
  public  class IssueTrackerService:IssueTracketDataService<Issue>, IIssueTrackerService
    {
        private readonly IMapper _mapper;
        public IssueTrackerService(IssuetrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public async Task<IssueDTO> CreateIssue(IssueDTO IssueDTO)
        {
            try
            {
                Issue Issue = this._mapper.Map<Issue>(IssueDTO);
                Issue.CreatedOn = DateTime.Now;
                Issue.ModifiedOn = DateTime.Now;
                await this.AddAsyn(Issue);
                return IssueDTO;
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
        public async Task<IssueDTO> UpdateIssue(IssueDTO IssueDTO)
        {
            try
            {
                Issue Issue = this._mapper.Map<Issue>(IssueDTO);
                Issue.ModifiedOn = DateTime.Now;
                await this.UpdateAsyn(Issue, Issue.IssueId);
                return IssueDTO;
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
        public async Task<IssueDTO> GetIssue(int Issueid)
        {
            try
            {
                return this._mapper.Map<IssueDTO>(await this.GetAsync(Issueid));
            }
            catch (Exception ex)  {

                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
        public async Task<IList<IssueDTO>> GetIssues(string number)
        {

            try
            {
                if (string.IsNullOrEmpty(number))
                {
                    var lst = await this.GetAllAsyn();
                    var issues = this._mapper.Map<List<IssueDTO>>(lst.ToList());
                    return issues.ToList();
                }
                else
                {
                    var lst = await this.FindAllAsync(ls => ls.TicketNumber.Contains(number));
                    var issues = this._mapper.Map<List<IssueDTO>>(lst.ToList());
                    return issues.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }

        }
        public async Task<Paging<IssueDTO>> GetIssues(PagingParameter pagingParameter)
        {
            var books = await this.GetAllAsyn();
            var source = books.Skip((pagingParameter.CurrentPage - 1) * pagingParameter.PageSize).Take(pagingParameter.PageSize);
            var sourcedto = this._mapper.Map<List<IssueDTO>>(source.ToList());
            var PageCount = (int)Math.Ceiling((double)books.Count / pagingParameter.PageSize);

            Paging<IssueDTO> response = new Paging<IssueDTO>
            {
                CurrentPage = pagingParameter.CurrentPage,
                PageCount = PageCount,
                TotalCount = books.Count,
                Items = sourcedto,
                PageSize = pagingParameter.PageSize
            };
            response.Pages = new List<int>();
            for (int i = 1; i <= PageCount; i++)
            {
                response.Pages.Add(i);
            }
            return response;
        }
        public async Task<bool> DeleteIssue(int Id)
        {
            try
            {
                await this.DeleteAsyn(this.Get(Id));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }

        }
    }
}
