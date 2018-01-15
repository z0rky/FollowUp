using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FollowUp.Models
{
    public class User : IdentityUser
    {
        

        public ICollection<Issue> MyIssues { get; set; }

        public ICollection<ExtraInfo> MyExtraInfo { get; set; }


    }
}