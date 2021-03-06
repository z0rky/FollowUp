﻿using System;
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
                issue.StartDateTime = DateTime.Now;
                
                _context.Issues.Add(issue);
            }
            else
            {
                var IssueInDb = _context.Issues.Single(c => c.Id == issue.Id);
                IssueInDb.Description = issue.Description;
                DateTime datum = DateTime.Today;
                //IssueInDb.StartDateTime = DateTime.Today;
                string dateString = datum.ToShortDateString();
                IssueInDb.StartDateTime = DateTime.Parse(dateString);
                IssueInDb.IssueExtraInfo = issue.IssueExtraInfo;
                IssueInDb.IssuePriority = issue.IssuePriority;
                IssueInDb.Subject = issue.Subject;
                //voegt datum niet toe ?

                //issue.AspNetUserId = User.Identity.GetUserId();
                //issue.IssueState = IssueState.Nieuw;
                //issue.StartDateTime = DateTime.Today;
                //_context.Issues.Add(issue);
            }
            _context.SaveChanges();
            return RedirectToAction("IndexMyIssues", "Issues", issue);
        }

        public ActionResult Details(int? Id)
        {
            var Issue = _context.Issues.SingleOrDefault(c => c.Id == Id);

            if (Issue == null)
            {
                return HttpNotFound();
            }
            return View("Details", Issue);
        }

        public ActionResult Assign(int? Id)
        {
            var Issue = _context.Issues.SingleOrDefault(c => c.Id == Id);
            if (Issue == null) return HttpNotFound();

            var solveUsers = (from u in _context.Users
                             // where u.RoleName == "Solver"
                              select new Gebruiker { Id = u.Id, Email = u.Email }).ToList();
            var model = new IssuesAssignModel
            {
                Issue = Issue,
                SolveUsers = solveUsers
            };

            return View("Assign", model);
        }

        [HttpPost]
        public ActionResult AssignSave(IssuesAssignModel IssuesAssignModel)
        {
            if (IssuesAssignModel == null) Redirect("IndexDispatcher");

            var Issue = _context.Issues.SingleOrDefault(c => c.Id == IssuesAssignModel.Issue.Id);
            Issue.AssignedToId = IssuesAssignModel.Issue.AssignedToId;

            _context.SaveChanges();
            return RedirectToAction("IndexDispatcher", "Issues");
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
            string currentUserId = User.Identity.GetUserId();

            var AllIssuesAssigned = (from b in _context.Issues
                                     join u in _context.Users on b.AspNetUserId equals u.Id
                                     where b.AssignedToId ==null
                                     select new IssueVerantwoordelijkPersoonManager { Issue = b, Gerbuiker = u }).ToList();


            return View("IndexWithDetail", AllIssuesAssigned);
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
            Issue issue = new Issue();
            issue = TeCancelen;
            return View("CancelManager", issue );
        }

        [HttpPost]
        public ActionResult Cancel(Issue issue)
        {   
           var issueInDb = _context.Issues.Single(i => i.Id == issue.Id);
            issueInDb.IssueState = IssueState.Canceled;
            issueInDb.CancelMessage = issue.CancelMessage;
            _context.SaveChanges();

            string currentUserId = User.Identity.GetUserId();

            var AllIssuesManager = (from b in _context.Issues
                join u in _context.Users on b.AspNetUserId equals u.Id
                where u.ManagerId == currentUserId
                select new IssueVerantwoordelijkPersoonManager { Issue = b, Gerbuiker = u }).ToList();


            return View("IndexVerantwoordelijkPersonenManager", AllIssuesManager);

            

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