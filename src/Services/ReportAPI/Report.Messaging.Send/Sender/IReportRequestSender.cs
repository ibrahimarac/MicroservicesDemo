using Assesment.Core.Models;
using System;

namespace Report.Messaging.Send.Sender
{
    public interface IReportRequestSender
    {
        bool SendReportRequest(RaporInfo rapor);
    }
}
