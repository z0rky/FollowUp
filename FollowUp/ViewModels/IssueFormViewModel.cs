using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FollowUp.Models;

namespace FollowUp.ViewModels
{
    public class IssueFormViewModel
    {
        public Priority PriorityEnum { get; set; }

        public IssueState IssueStateEnum { get; set; }

        public Issue Issue { get; set; }
    }
}