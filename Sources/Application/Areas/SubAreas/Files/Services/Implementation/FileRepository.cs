using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mmu.SsrsDownloader.Areas.Orchestration.Models;

namespace Mmu.SsrsDownloader.Areas.SubAreas.Files.Services.Implementation
{
    public class FileRepository : IFileRepository
    {
        private const string BasePath = @"C:\ReportDownloads";

        public IReadOnlyCollection<long> LoadAlreadyPersistedIds()
        {
            var allFileNames = Directory
                .GetFiles(BasePath)
                .Select(Path.GetFileNameWithoutExtension);

            var ids = allFileNames.Select(long.Parse).ToList();

            return ids;
        }

        public void SaveReport(Report report)
        {
            var fileName = Path.Combine(BasePath, report.ReceiptDeclarationId.ToString());
            fileName = Path.ChangeExtension(fileName, ".pdf");

            File.WriteAllBytes(fileName, report.Content);
        }
    }
}