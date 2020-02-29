using AJ.IssueTracker.Common.DTO;
using AJ.IssueTracker.DataAccess.Abstraction;
using AJ.IssueTracker.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJ.IssueTracker.Business.Abstraction
{
  public  interface INotesService : IIssueTrackerDataService<IssueNote>
    {
        Task<IList<IssueNoteDTO>> GetNotes(int issueId);
        Task<IssueNoteDTO> CreateNotes(IssueNoteDTO notes);
    }
   
}
