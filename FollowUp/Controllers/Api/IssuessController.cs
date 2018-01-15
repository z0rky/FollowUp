using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web.Http;
using FollowUp.Models;


namespace FollowUp.Controllers.Api
{
    public class IssuessController : ApiController
    {
        private ApplicationDbContext _context;
        
        public IssuessController()
        {
            _context = new ApplicationDbContext();
           
        }

        public IEnumerable<Issue> GetIssues()
        {
            return _context.Issues.ToList();
        }

        //GET  /api/locatie/1
        [HttpGet]
        public Issue GetIssue(int id)
        {
            var issue = _context.Issues.SingleOrDefault(c => c.Id == id);

            if (issue == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return issue;
        }

        //PUT /api/issues/1
        [HttpPut]
        public void PutIssue(int Id)
        {
            if (!ModelState.IsValid)

                           throw new HttpResponseException(HttpStatusCode.BadRequest);

                var IssueInDb = _context.Issues.SingleOrDefault(c => c.Id == Id);

            if (IssueInDb == null)

                throw new HttpResponseException(HttpStatusCode.NotFound);
           
                IssueInDb.IssueState = IssueState.Canceled;
                //IssueInDb.IssuePriority = issue.IssuePriority;
                //IssueInDb.Subject = issue.Subject;
                //IssueInDb.Description = issue.Description;
                //IssueInDb.StartDateTime = issue.StartDateTime;
                //IssueInDb.AspNetUserId = issue.AspNetUserId;
                //IssueInDb.IssueExtraInfo = issue.IssueExtraInfo;
            _context.SaveChanges();




        }
        [HttpDelete]
        public void DeleteIssue(int Id)
        {
            var IssueInDb = _context.Issues.SingleOrDefault(c => c.Id == Id);

            if (IssueInDb == null)

                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Issues.Remove(IssueInDb);
            _context.SaveChanges();

        }
    }
}
