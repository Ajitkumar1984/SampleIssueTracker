﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJ.IssueTracker.DataAccess.Entities
{
   public class IssueNote
    {
        [Key]
        public int NotesId { get; set; }
        public int IssueId { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
