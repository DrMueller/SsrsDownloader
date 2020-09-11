using System;
using System.Threading.Tasks;
using Mmu.SsrsDownloader.Areas.SubAreas.Files.Services;
using Mmu.SsrsDownloader.Areas.SubAreas.Ids.Services;
using Mmu.SsrsDownloader.Areas.SubAreas.ServiceCall.Services;

namespace Mmu.SsrsDownloader.Areas.Orchestration.Services.Implementation
{
    public class ReportDownloader : IReportDownloader
    {
        private readonly IFileRepository _fileRepo;
        private readonly IIdProvider _idProvider;
        private readonly IReportSeviceCaller _serviceCaller;

        public ReportDownloader(
            IFileRepository fileRepo,
            IReportSeviceCaller serviceCaller,
            IIdProvider idProvider)
        {
            _fileRepo = fileRepo;
            _serviceCaller = serviceCaller;
            _idProvider = idProvider;
        }

        public async Task DownloadAllReportsAsync()
        {
            Console.WriteLine("Fetching IDs to download..");
            var receiptDeclarationIds = await _idProvider.ProvideIdsToDownloadAsync();
            Console.WriteLine($"Downloading {receiptDeclarationIds.Count} reports..");

            foreach (var id in receiptDeclarationIds)
            {
                try
                {
                    Console.WriteLine($"Downloading {id}..");
                    var report = await _serviceCaller.CallServiceAsync(id);
                    Console.WriteLine($"Persisting {id}..");
                    _fileRepo.SaveReport(report);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + " " + ex.StackTrace);
                }
            }

            Console.WriteLine("Finished");
        }
    }
}