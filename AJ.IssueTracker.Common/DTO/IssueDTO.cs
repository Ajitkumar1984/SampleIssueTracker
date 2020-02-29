using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AJ.IssueTracker.Common.DTO
{
  public   class IssueDTO
    {
        public IssueDTO()
        {
            //IssueId = new Guid();
            Products = new List<SelectListItem>();
            Reasons = new List<SelectListItem>();
            Statuses = new List<SelectListItem>();
            Notes = new List<IssueNoteDTO>();
        }
        
        public int IssueId { get; set; }
        [Required(ErrorMessage ="Product is Required",AllowEmptyStrings =false)]
        [Display(Name ="Product")]
        public string ProductId { get; set; }
        [Required(ErrorMessage = "Reason is Required",AllowEmptyStrings =false)]
        [Display(Name = "Reason")]
        public string ReasonId { get; set; }
        [Required(ErrorMessage = "Customer Information is Required")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please provide issue detail")]
        [Display(Name = "Issue Detail")]
        public string Detail { get; set; }
        [Required(ErrorMessage = "Please provide status")]
        [Display(Name = "Status")]
        public string Status { get; set; }
        public string TicketNumber { get; set; }
        [Display(Name = "AssignedTo")]
        public string AssignedTo { get; set; }
        [Display(Name = "Resolution Detail")]
        public string ResolutionDetail { get; set; }
        [Required(ErrorMessage = "Please provide Founded On date")]
        [Display(Name = "Resolved On")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ResolvedOn { get; set; }
        [Display(Name = "Founded On")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FoundedOn { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedOn { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<IssueNoteDTO> Notes { get; set; }
        public List<SelectListItem> Products { get; set; }
        public List<SelectListItem> Reasons { get; set; }
        public List<SelectListItem> Statuses { get; set; }
    }
}
