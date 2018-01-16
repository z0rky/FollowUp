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
        [Display(Name = "Subject", ResourceType = typeof(Resources.Resource))]
        public String Subject { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Description", ResourceType = typeof(Resources.Resource))]
        public String Description { get; set; }

        [Display(Name = "IssuePriority", ResourceType = typeof(Resources.Resource))]
        public Priority IssuePriority { get; set; }
        //public Priority PriorityIssue { get; set; }

        [Display(Name = "StartDateTime", ResourceType = typeof(Resources.Resource))]
        public DateTime StartDateTime;

        [Display(Name = "IssueState", ResourceType = typeof(Resources.Resource))]
        public IssueState IssueState { get; set; }

        [Display(Name = "IssueExtraInfo", ResourceType = typeof(Resources.Resource))]
        public virtual ICollection<ExtraInfo> IssueExtraInfo { get; set; }

        [Display(Name = "AspNetUserId", ResourceType = typeof(Resources.Resource))]
        public string AspNetUserId { get; set; }

    }
}