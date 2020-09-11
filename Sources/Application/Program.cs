using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.SsrsDownloader.Areas.Orchestration.Services;
using StructureMap;

namespace Mmu.SsrsDownloader
{
    [PublicAPI]
    public static class Program
    {
        public static void Main(string[] args)
        {
            var container = new Container(
                cfg =>
                {
                    cfg.Scan(
                        scanner =>
                        {
                            scanner.AssemblyContainingType(typeof(Program));
                            scanner.LookForRegistries();
                        });
                });

            var downloader = container.GetInstance<IReportDownloader>();

            var downloadTask = downloader.DownloadAllReportsAsync();

#pragma warning disable VSTHRD002 // Avoid problematic synchronous waits
            Task.WaitAll(downloadTask);
#pragma warning restore VSTHRD002 // Avoid problematic synchronous waits

            Console.ReadKey();
        }
    }
}