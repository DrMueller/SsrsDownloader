using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.SsrsDownloader.Areas.SubAreas.Files.Services;

namespace Mmu.SsrsDownloader.Areas.SubAreas.Ids.Services.Implementation
{
    public class IdProvider : IIdProvider
    {
        private readonly IFileRepository _fileRepo;

        public IdProvider(IFileRepository fileRepo)
        {
            _fileRepo = fileRepo;
        }

        public Task<IReadOnlyCollection<long>> ProvideIdsToDownloadAsync()
        {
            var allIds = new List<long>
            {
                1001001, 1001002, 1001003,
            };

            var existingIds = _fileRepo.LoadAlreadyPersistedIds();
            var idsToDownload = allIds.Except(existingIds).ToList();

            return Task.FromResult<IReadOnlyCollection<long>>(idsToDownload);
        }
    }
}