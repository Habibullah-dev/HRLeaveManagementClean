using HR.LeaveManangement.Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManangement.Application.contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);


    }
}
