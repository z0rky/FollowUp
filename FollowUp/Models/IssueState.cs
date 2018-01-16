using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FollowUp.Models
{
    public enum IssueState
    {
        [Display(Name = "Nieuw", ResourceType = typeof(Resources.Resource))]
        Nieuw,
        [Display(Name = "Toegewezen", ResourceType = typeof(Resources.Resource))]
        Toegewezen,
        [Display(Name = "InBehandeling", ResourceType = typeof(Resources.Resource))]
        InBehandeling,
        [Display(Name = "Opgelost", ResourceType = typeof(Resources.Resource))]
        Opgelost,
        [Display(Name = "Afgesloten", ResourceType = typeof(Resources.Resource))]
        Afgesloten,
        [Display(Name = "Canceled", ResourceType = typeof(Resources.Resource))]
        Canceled,
        [Display(Name = "ExtraInfo", ResourceType = typeof(Resources.Resource))]
        ExtraInfo,
        [Display(Name = "Geweigerd", ResourceType = typeof(Resources.Resource))]
        Geweigerd
    }
}