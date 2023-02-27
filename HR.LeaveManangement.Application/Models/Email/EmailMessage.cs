﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.Models.Email
{
    public class EmailMessage
    {
        public string To { get; set; }

        public string From { get; set; }    

        public string Subject { get; set; } 

        public string Body { get; set; }
    }
}
