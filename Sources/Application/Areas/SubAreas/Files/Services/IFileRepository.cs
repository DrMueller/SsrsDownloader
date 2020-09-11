using System.Collections.Generic;
using Mmu.SsrsDownloader.Areas.Orchestration.Models;

namespace Mmu.SsrsDownloader.Areas.SubAreas.Files.Services
{
    public interface IFileRepository
    {
        IReadOnlyCollection<long> LoadAlreadyPersistedIds();

        void SaveReport(Report report);
    }
}