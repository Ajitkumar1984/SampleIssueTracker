using AJ.IssueTracker.Business.Abstraction;
using AJ.IssueTracker.Business.Services;
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
    public class IssueTrackerController : ApiController
    {
        private IIssueTrackerService _issueTrackerService;
        private ICategoryService _categoryService;
        private INotesService _notesService;
        public IssueTrackerController(IIssueTrackerService issueTrackerService, ICategoryService categoryService, INotesService notesService)
        {
            _issueTrackerService = issueTrackerService;
            _categoryService = categoryService;
            _notesService = notesService;
        }
        // GET api/<controller>
        public async Task<IHttpActionResult> Get([FromUri]string number)
        {
            try
            {
                var lst = await _issueTrackerService.GetIssues(number);
                return Ok(lst.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET api/<controller>
        public async Task<IHttpActionResult> Get([FromUri]int id)
        {
            try
            {
                var lst = await _issueTrackerService.GetIssue(id);
                var notes = await _notesService.GetNotes(id);
                lst.Notes = notes.ToList();
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST api/<controller>
        public async Task<IHttpActionResult> Post([FromBody]IssueDTO value)
        {
            try
            {
                await _issueTrackerService.CreateIssue(value);
                var category = await _categoryService.GetCategory(value.ProductId);
                IssueNoteDTO notes = new IssueNoteDTO()
                { IssueId = value.IssueId, Notes = value.ResolutionDetail, CreatedBy = "Test", CreatedOn = DateTime.Now, ModifiedBy = "Test", ModifiedOn = DateTime.Now };
                await _notesService.CreateNotes(notes);
                category.Sequence = Convert.ToInt32(value.TicketNumber);
                await _categoryService.UpdateCategory(category);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        public async Task<IHttpActionResult> Put([FromBody]IssueDTO value)
        {
            var lst = await _issueTrackerService.GetIssue(value.IssueId);
            if (lst == null)
            {
                return BadRequest();
            }
            value.CreatedOn = lst.CreatedOn;
            value.CreatedBy = lst.CreatedBy;
            value.ResolvedOn = lst.ResolvedOn;

            IssueNoteDTO notes = new IssueNoteDTO()
            { IssueId = value.IssueId, Notes = value.ResolutionDetail, CreatedBy = lst.CreatedBy, CreatedOn = lst.CreatedOn, ModifiedBy = "Test", ModifiedOn = DateTime.Now };
            await _notesService.CreateNotes(notes);

            await _issueTrackerService.UpdateIssue(value);
            return Ok(value);
        }
    }
}