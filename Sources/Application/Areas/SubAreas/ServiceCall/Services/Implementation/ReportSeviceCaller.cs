using System.Threading.Tasks;
using Mmu.SsrsDownloader.Areas.Orchestration.Models;

namespace Mmu.SsrsDownloader.Areas.SubAreas.ServiceCall.Services.Implementation
{
    public class ReportSeviceCaller : IReportSeviceCaller
    {
        public ReportSeviceCaller()
        {
            
        }

        public Task<Report> CallServiceAsync(long receiptDeclarationId)
        {
            var tra = new Report(123, new byte[0]);

            return Task.FromResult(tra);
        }
    }
}