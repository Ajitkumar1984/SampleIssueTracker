using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJ.IssueTracker.DataAccess.Entities
{
   public class Issue
    {
        [Key]
        public int IssueId { get; set; }
        public string ProductId { get; set; }
        public string ReasonId { get; set; }
        public int CustomerId { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }
        public string TicketNumber { get; set; }
        public string AssignedTo { get; set; }
        public string ResolutionDetail { get; set; }
        public DateTime ResolvedOn { get; set; }
        public DateTime FoundedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
