using System.Threading.Tasks;

namespace Mmu.SsrsDownloader.Areas.Orchestration.Services
{
    public interface IReportDownloader
    {
        Task DownloadAllReportsAsync();
    }
}