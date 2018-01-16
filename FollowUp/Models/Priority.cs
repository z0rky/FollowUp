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
        [Display(Name ="Low", ResourceType = typeof(Resources.Resource))]
        LowPriority,
        [Display(Name = "Medium", ResourceType = typeof(Resources.Resource))]
        MediumPriority,
        [Display(Name = "High", ResourceType = typeof(Resources.Resource))]
        HighPriority,
        [Display(Name = "Immediate", ResourceType = typeof(Resources.Resource))]
        ImmediatePriority
       
    }
}