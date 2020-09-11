using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.SsrsDownloader.Areas.Orchestration.Services
{
    public interface IReportDownloader
    {
        Task DownloadAllReportsAsync();
    }
}
