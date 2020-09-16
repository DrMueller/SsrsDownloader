using Mmu.SsrsDownloader.Areas.Orchestration.Models;

namespace Mmu.SsrsDownloader.Areas.SubAreas.ServiceCall.Services
{
    public interface IReportSeviceCaller
    {
        Report CallService(long receiptDeclarationId);
    }
}