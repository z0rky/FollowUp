using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FollowUp.Models
{
    public class ExtraInfo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "InfoVraag", ResourceType = typeof(Resources.Resource))]
        public String Vraag { get; set; }

        private DateTime datumVraag;

        [Display(Name = "InfoUser", ResourceType = typeof(Resources.Resource))]
        public string UserId { get; set; }

        [Display(Name = "InfoIssue", ResourceType = typeof(Resources.Resource))]
        public int IssueId { get; set; }

        [Display(Name = "InfoDatumVraag", ResourceType = typeof(Resources.Resource))]
        public DateTime DatumVraag
        {
            get { return datumVraag; }
            set { datumVraag = DateTime.Now; }
        }
    }
}