using System.Threading.Tasks;
using Mmu.SsrsDownloader.Areas.Orchestration.Models;

namespace Mmu.SsrsDownloader.Areas.SubAreas.ServiceCall.Services
{
    public interface IReportSeviceCaller
    {
        Task<Report> CallServiceAsync(long receiptDeclarationId);
    }
}