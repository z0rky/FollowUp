using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FollowUp.Models;
using Microsoft.Ajax.Utilities;

namespace FollowUp.ViewModels
{
    public class IssueVerantwoordelijkPersoonManager
    {
        //public string Id { get; set; }
        //public string Email { get; set; }
        //public string Subject { get; set; }
        //public string Description { get; set; }
        //public string IssuePriority { get; set; }
        //public string StartDateTime { get; set; }
        //public string IssueState { get; set; }

        //public IEnumerable<Issue> Issue { get; set; }
        //public IEnumerable<ApplicationUser>  Gerbuiker { get; set; }
        public Issue Issue { get; set; }
        public ApplicationUser Gerbuiker { get; set; }
    }
}