using System;

namespace Report.Messaging.Send.Sender
{
    public interface IReportRequestSender
    {
        bool SendReportRequest(string konum);
    }
}
