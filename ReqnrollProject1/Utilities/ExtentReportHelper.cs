using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Utilities
{
    public class ExtentReportHelper
    {
        public static ExtentReports extent;
        public static ExtentTest test;

        public static void InitializeReport()
        {
            string reportPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Reports",
                "ExtentReport.html");

            ExtentSparkReporter sparkReporter =
                new ExtentSparkReporter(reportPath);

            extent = new ExtentReports();

            extent.AttachReporter(sparkReporter);
        }

        public static void FlushReport()
        {
            extent.Flush();
        }
    }
}
