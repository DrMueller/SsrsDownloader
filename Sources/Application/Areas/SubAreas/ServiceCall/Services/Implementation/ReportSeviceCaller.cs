using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Reporting.WebForms;

namespace Mmu.SsrsDownloader.Areas.SubAreas.ServiceCall.Services.Implementation
{
    // https://stackoverflow.com/questions/45064435/execute-ssrs-report-from-c-sharp-save-as-pdf
    public class ReportSeviceCaller : IReportSeviceCaller
    {
        // The relative path can be navigates from the reporting web ui to the subfolder
        // Starting / is important, ReportName without extension
        private const string RelativeReportPath = "/SubPath/ReportName";

        // This can be found in Report Server Manager as Server URL.
        private const string ReportServerUrl = "http://srv-dapp04/ReportServer_SQL2012";

        private readonly ServerReport _serverReport;

        public ReportSeviceCaller()
        {
            var rv = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Remote,
                AsyncRendering = false,
            };

            _serverReport = rv.ServerReport;
            _serverReport.ReportServerUrl = new Uri(ReportServerUrl);
            _serverReport.ReportPath = RelativeReportPath;
        }

        public Orchestration.Models.Report CallService(long receiptDeclarationId)
        {
            var paramsList = new List<ReportParameter>
            {
                new ReportParameter("REC_DECL_ID", receiptDeclarationId.ToString()),
            };

            _serverReport.SetParameters(paramsList);

            var reportContent = _serverReport.Render(
                "PDF",
                null,
                out _,
                out _,
                out _,
                out _,
                out var warnings);

            if (warnings?.Any() == true)
            {
                var warn = string.Join(", ", warnings.ToList());
                Console.WriteLine("Warnings: " + warn);
            }

            var report = new Orchestration.Models.Report(receiptDeclarationId, reportContent);

            return report;
        }
    }
}