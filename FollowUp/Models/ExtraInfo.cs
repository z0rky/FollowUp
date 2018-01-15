using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FollowUp.Models
{
    public class ExtraInfo
    {
        public int Id { get; set; }

        public String Vraag { get; set; }

        private DateTime datumVraag;

        public int UserId { get; set; }

        public int IssueId { get; set; }

        public DateTime DatumVraag
        {
            get { return datumVraag; }
            set { datumVraag = DateTime.Now; }
        }



    }
}