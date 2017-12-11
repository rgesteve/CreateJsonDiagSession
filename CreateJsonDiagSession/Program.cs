namespace CreateJsonDiagSession
{
    using System;
    using Microsoft.DiagnosticsHub.Packaging.InteropEx;
    using global::DiagnosticsHub.Packaging.Interop;

    class Program
    {
        static void Main(string[] args)
        {
            // This is the tool that will be analyzing the data
            var cpuToolId = new Guid("96f1f3e8-f762-4cd2-8ed9-68ec25c2c722");
            using (var package = DhPackage.CreateLegacyPackage())
            {
                package.AddTool(ref cpuToolId);

                // Contains the data to analyze
                package.CreateResourceFromPath(
                    "DiagnosticsHub.Resource.DWJsonFile",
                    @"<UPDATE_PATH>\Sample1.dwjson",
                    null,
                    CompressionOption.CompressionOption_Normal);

                // Counter data to show in swimlane
                package.CreateResourceFromPath(
                    "DiagnosticsHub.Resource.CountersFile",
                    @"<UPDATE_PATH>\Session.counters",
                    null,
                    CompressionOption.CompressionOption_Normal);

                // You can add the commit option (CommitOption.CommitOption_CleanUpResources) and it will delete
                // the resources added from disk after they have been committed to the DiagSession
                package.CommitToPath(@"demo", CommitOption.CommitOption_Archive);
            }
        }
    }
}
