using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactReport.Domain.Common
{
    public interface IAuditable
    {
        public DateTime CreateDate { get; set; }
        public DateTime LastupDate { get; set; }
    }
}
