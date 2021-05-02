﻿using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAssessment.UI.Event
{
    public class AfterUserLoginSavedEvent:PubSubEvent<AfterUserLoginSavedEventArgs>
    {

    }

    public class AfterUserLoginSavedEventArgs
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}
