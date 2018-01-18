using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FollowUp.Models;
using FollowUp.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Net;

namespace FollowUp.Controllers
{
    public class IssuesController : Controller
    {
        private ApplicationDbContext _context;
        
        public IssuesController()
        {
            _context= new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult IndexMyIssues()
        {
            string currentUserId = User.Identity.GetUserId();

            var MyIssues = (from b in _context.Issues
                where b.AspNetUserId == currentUserId
                select b).ToList();


            
            
            return View("indexMyIssues",MyIssues);
        }

       
        public ActionResult New()
        {
            var viewModel = new IssueFormViewModel
            {

            };

            return View("IssueForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Issue issue)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new IssueFormViewModel
                {
                    Issue = issue

                };
                return View("IndexMyIssues", viewModel);
            }
            if (issue.Id == 0)
            {
                
                string currentUserId = User.Identity.GetUserId();
                issue.AspNetUserId = currentUserId;
                issue.IssueState = IssueState.Nieuw;
               
                issue.StartDateTime = DateTime.Today;
                
                _context.Issues.Add(issue);
            }
            else
            {
                var IssueInDb = _context.Issues.Single(c => c.Id == issue.Id);
                IssueInDb.Description = issue.Description;
                IssueInDb.StartDateTime = issue.StartDateTime;
                IssueInDb.IssueExtraInfo = issue.IssueExtraInfo;
                IssueInDb.IssuePriority = issue.IssuePriority;
                IssueInDb.Subject = issue.Subject;
                


            }
            _context.SaveChanges();
            return RedirectToAction("IndexMyIssues", "Issues", issue);
        }

        public ActionResult Details(int Id)
        {
            var Issue = _context.Issues.SingleOrDefault(c => c.Id == Id);

            if (Issue == null)
            {
                return HttpNotFound();
            }
            return View("Details", Issue);
        }

        public ActionResult IndexVerantwoordelijkPersonenManager()
        {
            string currentUserId = User.Identity.GetUserId();

                var AllIssuesManager = (from b in _context.Issues
                join u in _context.Users on b.AspNetUserId equals u.Id
                where u.ManagerId==currentUserId
                select new IssueVerantwoordelijkPersoonManager { Issue= b,Gerbuiker= u}).ToList();


            return View("IndexVerantwoordelijkPersonenManager", AllIssuesManager);
        }

        public ActionResult IndexDispatcher()
        {
            throw new NotImplementedException();
        }

        public ActionResult Solve()
        {
            string currentUserId = User.Identity.GetUserId();

            var AllIssuesAssigned = (from b in _context.Issues
                                     join u in _context.Users on b.AspNetUserId equals u.Id
                                     where b.AssignedToId == currentUserId
                                     select new IssueVerantwoordelijkPersoonManager { Issue = b, Gerbuiker = u }).ToList();


            return View("IndexWithDetail", AllIssuesAssigned);
        }

        public ActionResult IndexAllIssuesAdministrator()
        {
            throw new NotImplementedException();
        }

        public ActionResult CancelManager(int id)
        {
            var TeCancelen = _context.Issues.SingleOrDefault(c => c.Id == id);

            return View("CancelManager", TeCancelen );
        }

        public ActionResult NewInfo(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var viewModel = new ExtraInfo { Vraag = "Stel uw vraag", IssueId = (int) id };

            return View("InfoForm", viewModel);
        }

        [HttpPost]
        public ActionResult SaveInfo(ExtraInfo extraInfo)
        {
            if (!ModelState.IsValid) Redirect("IndexMyIssues");

            if (extraInfo.IssueId == 0) Redirect("IndexMyIssues");
            else
            {
                extraInfo.UserId = User.Identity.GetUserId();
                extraInfo.DatumVraag = DateTime.Today;

                _context.ExtraInfo.Add(extraInfo);
            }
            _context.SaveChanges();
            return RedirectToAction("IndexMyIssues", "Issues", extraInfo);
        }
    }
}