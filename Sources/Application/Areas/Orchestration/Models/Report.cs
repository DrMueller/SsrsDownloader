namespace Mmu.SsrsDownloader.Areas.Orchestration.Models
{
    public class Report
    {
        public Report(long receiptDeclarationId, byte[] content)
        {
            ReceiptDeclarationId = receiptDeclarationId;
            Content = content;
        }

        public byte[] Content { get; }

        public long ReceiptDeclarationId { get; }
    }
}