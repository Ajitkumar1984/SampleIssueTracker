using AJ.IssueTracker.Common.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJ.IssueTracker.WebUI.Models
{
    public class IssueTrackerModel
    {
        public IssueTrackerModel()
        {
            Issue = new IssueDTO();
            ListIssues = new List<IssueDTO>();
            ListCategories = new List<CategoryDTO>();
        }
        [Required(ErrorMessage = "Please provide ticket number", AllowEmptyStrings = false)]
        [Display(Name = "Search By Ticket Number")]
        public string TicketNumber { get; set; }
        public IssueDTO Issue { get; set; }
        public IList<IssueDTO> ListIssues { get; set; }
        public IList<CategoryDTO> ListCategories
        {
            get; set;

        }
    }
}