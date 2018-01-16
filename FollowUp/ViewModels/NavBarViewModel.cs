using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FollowUp.ViewModels
{
    public class NavBarViewModel
    {
        public bool User { get; set; }
        public bool Manager { get; set; }
        public bool Solver { get; set; }
        public bool Dispatcher { get; set; }
        public bool Administrator { get; set; }
    }
}