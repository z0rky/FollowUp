using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FollowUp.Models
{
    public enum IssueState
    {
        
        Nieuw,
        Toegewezen,
        InBehandeling,
        Opgelost,
        Afgesloten,
        Canceled,
        ExtraInfo,
        Geweigerd
    }
}