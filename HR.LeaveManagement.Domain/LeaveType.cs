using HR.LeaveManagement.Domain.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Domain;

public class LeaveType : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public int DefaultDays { get; set; }
}
