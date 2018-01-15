using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FollowUp.Models
{
    public enum Priority
    {    
        [Display(Name ="Low")]
        LowPriority,
        [Display(Name = "Medium")]
        MediumPriority,
        [Display(Name = "High")]
        HighPriority,
        [Display(Name = "Immediate")]
        ImmediatePriority
       
    }
}