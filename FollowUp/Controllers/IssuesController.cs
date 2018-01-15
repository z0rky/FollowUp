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
           
             var IssuesListUser = _context.Issues;
            
            return View("indexMyIssues",IssuesListUser);
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
            throw new NotImplementedException();
        }

        public ActionResult IndexDispatcher()
        {
            throw new NotImplementedException();
        }

        public ActionResult Solve()
        {
            throw new NotImplementedException();
        }

        public ActionResult IndexAllIssuesAdministrator()
        {
            throw new NotImplementedException();
        }
    }
}