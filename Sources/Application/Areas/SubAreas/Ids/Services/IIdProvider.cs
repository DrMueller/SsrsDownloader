using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mmu.SsrsDownloader.Areas.SubAreas.Ids.Services
{
    public interface IIdProvider
    {
        Task<IReadOnlyCollection<long>> ProvideIdsToDownloadAsync();
    }
}