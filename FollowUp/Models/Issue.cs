using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace FollowUp.Models
{
    public class Issue
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Subject { get; set; }

        [Required]
        [StringLength(255)]
        public String Description { get; set; }

        public Priority IssuePriority { get; set; }
        //public Priority PriorityIssue { get; set; }

        public DateTime StartDateTime;

        public IssueState IssueState { get; set; }

        public virtual ICollection<ExtraInfo> IssueExtraInfo { get; set; }

        public string AspNetUserId { get; set; }






    }
}