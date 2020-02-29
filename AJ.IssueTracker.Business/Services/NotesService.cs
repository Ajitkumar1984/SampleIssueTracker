using AJ.IssueTracker.Business.Abstraction;
using AJ.IssueTracker.Common.DTO;
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
    public class NotesService : IssueTracketDataService<IssueNote>, INotesService
    {
        private readonly IMapper _mapper;
        public NotesService(IssuetrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public async Task<IssueNoteDTO> CreateNotes(IssueNoteDTO notes)
        {
            try
            {
                IssueNote Issue = this._mapper.Map<IssueNote>(notes);
                Issue.CreatedOn = DateTime.Now;
                Issue.ModifiedOn = DateTime.Now;
                await this.AddAsyn(Issue);
                return notes;
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

        public async Task<IList<IssueNoteDTO>> GetNotes(int issueId)
        {
            try
            {
                return this._mapper.Map<IList<IssueNoteDTO>>(await this.FindAllAsync(x => x.IssueId == issueId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
