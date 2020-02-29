using AJ.IssueTracker.Common.DTO;
using AJ.IssueTracker.Services;
using AJ.IssueTracker.Services.Abstraction;
using AJ.IssueTracker.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AJ.IssueTracker.WebUI.Controllers
{
    public class IssueTrackerController : Controller
    {
        private ITrackerService tracker;
        public IssueTrackerController(ITrackerService trackerService)
        {
            tracker = trackerService;
        }
       
        // GET: IssueTracker
        public async Task<ActionResult> Index()
        {
            var responselist = await tracker.GetAllIssues();
            var categories = await tracker.GetAllCategories();
            IssueTrackerModel issueTrackerModel = new IssueTrackerModel
            {
                ListIssues = responselist.Value,
                ListCategories=categories.Value
            };
            return View(issueTrackerModel);
        }

        [HttpPost]
        public async Task<ActionResult> Index(IssueTrackerModel trackerModel)
        {

            var responselist = await tracker.GetAllIssues(trackerModel.TicketNumber);
            var categories = await tracker.GetAllCategories();
            IssueTrackerModel issueTrackerModel = new IssueTrackerModel
            {
                ListIssues = responselist.Value,
                ListCategories = categories.Value
            };
            return View(issueTrackerModel);
        }
       
        public async Task<ActionResult> Issue(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return null;
            }
            var categories = await tracker.GetCategory(code);
            var category = categories.Value;
            int newticket = Convert.ToInt32(category.Sequence) + 1;
            var Issue = await InitializeModel(new IssueDTO(), newticket.ToString());
            return View(Issue);
        }
      
        [HttpPost]
        public async Task<ActionResult> Issue(IssueDTO trackerModel)
        {
            if (ModelState.IsValid)
            {
                await this.tracker.CreateIssue(trackerModel);
            }

            trackerModel = await InitializeModel(trackerModel,trackerModel.TicketNumber);
            ModelState.AddModelError("Success", "Ticket created sucessfully.");
            return View(trackerModel);
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            var issue = await tracker.GetIssues(id);
            issue.Value = await InitializeModel(issue.Value, issue.Value.TicketNumber);
            return View(issue.Value);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(IssueDTO trackerModel)
        {
            if (ModelState.IsValid)
            {
                await this.tracker.UpdateIssue(trackerModel);
            }

            var issue = await tracker.GetIssues(trackerModel.IssueId.ToString());
            issue.Value = await InitializeModel(issue.Value, issue.Value.TicketNumber);
            return View(issue.Value);
        }


        public ActionResult Category()
        {
            var customer = new CategoryDTO();
            return View(customer);
        }
        [HttpPost]
        public async Task<ActionResult> Category(IssueDTO trackerModel)
        {
            if (ModelState.IsValid)
            {
                await this.tracker.CreateIssue(trackerModel);
            }
            var Products = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Select", Selected = true },
                new SelectListItem { Value = "1", Text = "Internet", Selected = false },
                new SelectListItem { Value = "2", Text = "Wireless/Mobile", Selected = false },
                new SelectListItem { Value = "3", Text = "BellTV", Selected = false }
            };
            var Reasons = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Select", Selected = true },
                new SelectListItem { Value = "1", Text = "Performance", Selected = false },
                new SelectListItem { Value = "2", Text = "Service not working", Selected = false },
                new SelectListItem { Value = "3", Text = "Cancellation", Selected = false }
            };
            var Issue = new IssueDTO { Products = Products, Reasons = Reasons };
            ModelState.AddModelError("Success", "Ticket created sucessfully.");
            return View(Issue);
        }

        private async Task<IssueDTO> InitializeModel(IssueDTO IssueDTO,string ticketnumber)
        {
            var categories = await tracker.GetAllCategories();
            var Products = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Select", Selected = true }
            };
            foreach (var item in categories.Value.ToList())
            {
                Products.Add(new SelectListItem { Value = item.Code, Text = item.CategoryName, Selected = false });
            }

            var Reasons = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Select", Selected = true },
                new SelectListItem { Value = "1", Text = "Performance", Selected = false },
                new SelectListItem { Value = "2", Text = "Service not working", Selected = false },
                new SelectListItem { Value = "3", Text = "Cancellation", Selected = false }
            };

            var Statuses = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Select", Selected = true },
                new SelectListItem { Value = "New", Text = "New", Selected = false },
                new SelectListItem { Value = "InProgress", Text = "In Progress", Selected = false },
                new SelectListItem { Value = "Resolved", Text = "Resolved", Selected = false }
            };

            IssueDTO.Products = Products;
            IssueDTO.Reasons = Reasons;
            IssueDTO.TicketNumber = ticketnumber;
            IssueDTO.Statuses = Statuses;
            IssueDTO.Status = string.IsNullOrEmpty(IssueDTO.Status) ? "New" : IssueDTO.Status;
            return IssueDTO;
        }
    }
}