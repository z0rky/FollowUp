using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FollowUp.Models;

namespace FollowUp.ViewModels
{
    public class IssuesAssignModel
    {
        public Issue Issue;
        public IEnumerable<Gebruiker> SolveUsers;
    }
}